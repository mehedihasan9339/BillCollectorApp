using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Models;
using BillCollectorApp.Services;
using BillCollectorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillCollectorApp.Controllers
{
    public class BillInfoController : Controller
    {
        private readonly IBillType _billTypeService;
        private readonly ICustomerInfo _customerInfo;
        private readonly IBillInfo _billInfoService;
        private readonly ISms _smsService;

        public BillInfoController(IBillType billTypeService, ICustomerInfo customerInfo, IBillInfo billInfoService, ISms smsService)
        {
            _billTypeService = billTypeService;
            _customerInfo = customerInfo;
            _billInfoService = billInfoService;
            _smsService = smsService;
        }

        public IActionResult CreateBillInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillInfo(CreateBillInfoVm model)
        {
            return View();
        }

        public async Task<IActionResult> GenerateBill()
        {
            var data = new GenerateBillVm
            {
                BillTypes = await _billTypeService.GetBillTypes()
            };

            return View(data);
        }

        [HttpPost("/api/ProcessBill")]
        public async Task<IActionResult> ProcessBill(GenerateBillVm model)
        {
            var customer = await _customerInfo.GetCustomerByBillTypeId(model.billTypeId);

            var bills = new List<BillInfo>();

            foreach (var item in customer)
            {
                bills.Add(new BillInfo
                {
                    Id = 0,
                    customerId = item.Id,
                    generateDate = DateTime.Now,
                    dueDate = DateTime.Now.AddDays(10),
                    bill = model.amount,
                    month = model.month,
                    year = model.year,
                    paymentMethod = string.Empty,
                    trxNo = string.Empty
                });
            }

            var result = await _billInfoService.SaveBillInfos(bills);


            return Ok(result);
        }

        [HttpGet("/api/GetBills")]
        public async Task<IActionResult> GetBills(int billTypeId, int year, string month)
        {
            var data = await _billInfoService.GetBills(billTypeId, year, month);

            return Ok(data);
        }
        [HttpGet("/api/UpdateBill")]
        public async Task<IActionResult> UpdateBill(int id, decimal? bill = 0)
        {
            var data = await _billInfoService.UpdateBill(id, bill);

            return Ok(data);
        }
        [HttpGet("/api/RemoveBill")]
        public async Task<IActionResult> RemoveBill(int id)
        {
            var data = await _billInfoService.RemoveBill(id);

            return Ok(data);
        }

        public async Task<IActionResult> CollectBill()
        {
            var data = new CollectBillVm
            {
                BillTypes = await _billTypeService.GetBillTypes()
            };
            return View(data);
        }

        [HttpGet("/api/GetCustomerByBillTypeId")]
        public async Task<IActionResult> GetCustomerByBillTypeId(int typeId)
        {
            var data = await _customerInfo.GetCustomerByBillTypeId(typeId);
            return Ok(data);
        }
        [HttpGet("/api/GetCustomerBills")]
        public async Task<IActionResult> GetCustomerBills(int customerId)
        {
            var data = await _customerInfo.GetCustomerBills(customerId);
            return Ok(data);
        }
        [HttpGet("/api/UpdatePaid")]
        public async Task<IActionResult> UpdatePaid(int id)
        {
            var data = await _customerInfo.UpdatePaid(id);

            var message = "Your bill has been paid successfully. Thank you.";

            await _smsService.SendSmsAsync("88" + data.customer.phone, message);

            return Ok(data);
        }
        [HttpGet("/api/CancelPayment")]
        public async Task<IActionResult> CancelPayment(int id)
        {
            var data = await _customerInfo.CancelPayment(id);

            var message = "Your bill has been cancelled.";

            await _smsService.SendSmsAsync("88" + data.customer.phone, message);

            return Ok(data);
        }
    }
}
