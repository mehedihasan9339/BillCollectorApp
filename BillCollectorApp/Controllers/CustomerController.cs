using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Models;
using BillCollectorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillCollectorApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerInfo _customerService;
        private readonly IBillType _billTypeService;

        public CustomerController(ICustomerInfo customerService, IBillType billTypeService)
        {
            _customerService = customerService;
            _billTypeService = billTypeService;
        }

        public async Task<IActionResult> CreateCustomer()
        {
            var data = new CreateCustomerVm
            {
                BillTypes = await _billTypeService.GetBillTypes()
            };

            return View(data);
        }
        [HttpPost("/api/CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerVm model)
        {
            try
            {
                var data = new CustomerInfo
                {
                    Id = model.id,
                    code = model.code,
                    name = model.name,
                    gender = model.gender,
                    phone = model.phone,
                    email = model.email,
                    address = model.address,
                    status = model.status,
                    companyId = model.companyId,
                    billTypeId = model.billTypeId
                };

                var result = await _customerService.SaveCustomer(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var data = new CreateCustomerVm
            {
                Customers = await _customerService.GetCustomers()
            };

            return View(data);
        }
    }
}
