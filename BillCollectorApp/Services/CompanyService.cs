using BillCollectorApp.Context;
using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillCollectorApp.Services
{
    public class CompanyService:ICompany
    {
        public readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveCompany(Company model)
        {
            if (model.Id > 0)
            {
                _context.Companies.Update(model);
            }
            else
            {
                _context.Companies.Add(model);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var data = await _context.Companies.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return data;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var data = await _context.Companies.AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<int> RemoveCompany(int id)
        {
            var data = await _context.Companies.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            _context.Companies.Remove(data);

            return await _context.SaveChangesAsync();
        }
    }
}
