using BillCollectorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillCollectorApp.Controllers
{
    public class BillInfoController : Controller
    {
        public IActionResult CreateBillInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillInfo(CreateBillInfoVm model)
        {
            return View();
        }
    }
}
