using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Models;
using BillCollectorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillCollectorApp.Controllers
{
    public class BillTypeController : Controller
    {
        private readonly IBillType _billTypeService;

        public BillTypeController(IBillType billTypeService)
        {
            _billTypeService = billTypeService;
        }

        public IActionResult CreateBillType()
        {
            return View();
        }


        [HttpPost("/api/CreateBillType")]
        public async Task<IActionResult> CreateBillType(BillTypeVm model)
        {
            try
            {
                var data = new BillType
                {
                    Id = model.id,
                    code = model.code,
                    name = model.name,
                    status = model.status
                };

                var result = await _billTypeService.SaveBillType(data);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(0);
            }
        }

        [HttpGet("/api/GetBillTypes")]
        public async Task<IActionResult> GetBillTypes()
        {
            var data = await _billTypeService.GetBillTypes();

            return Ok(data);
        }

        [HttpGet("/api/GetBillTypeById")]
        public async Task<IActionResult> GetBillTypeById(int id)
        {
            var data = await _billTypeService.GetBillTypeById(id);

            return Ok(data);
        }

        [HttpGet("/api/RemoveBillType")]
        public async Task<IActionResult> RemoveBillType(int id)
        {
            var data = await _billTypeService.RemoveBillType(id);

            return Ok(data);
        }
    }
}
