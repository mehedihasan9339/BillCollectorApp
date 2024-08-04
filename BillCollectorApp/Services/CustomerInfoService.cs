using BillCollectorApp.Context;
using BillCollectorApp.Data.Customer;
using BillCollectorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillCollectorApp.Services
{
    public class CustomerInfoService:ICustomerInfo
    {
        public readonly ApplicationDbContext _context;

        public CustomerInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveCustomer(CustomerInfo model)
        {
            if (model.Id > 0)
            {
                _context.CustomerInfos.Update(model);
            }
            else
            {
                _context.CustomerInfos.Add(model);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<CustomerInfo> GetCustomerById(int id)
        {
            var data = await _context.CustomerInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return data;
        }

        public async Task<IEnumerable<CustomerInfo>> GetCustomers()
        {
            var data = await _context.CustomerInfos.AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<int> RemoveCustomer(int id)
        {
            var data = await _context.CustomerInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            _context.CustomerInfos.Remove(data);

            return await _context.SaveChangesAsync();
        }
    }
}
