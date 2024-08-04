using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Models;
using BillCollectorApp.Services;
using BillCollectorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillCollectorApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _companyService;

        public CompanyController(ICompany companyService)
        {
            _companyService = companyService;
        }

        public IActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost("/api/CreateCompany")]
        public async Task<IActionResult> CreateCompany(CreateCompanyVm model)
        {
            try
            {
                var data = new Company
                {
                    Id = model.id,
                    code = model.code,
                    name = model.name,
                    phone = model.phone,
                    logo = model.logo,
                    email = model.email,
                    address = model.address,
                };

                var result = await _companyService.SaveCompany(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }
        }


        [HttpGet("/api/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var data = await _companyService.GetCompanies();

            return Ok(data);
        }
    }
}
