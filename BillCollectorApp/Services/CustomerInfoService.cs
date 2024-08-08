using BillCollectorApp.Context;
using BillCollectorApp.Data.Bill;
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
        public async Task<IEnumerable<CustomerInfo>> GetCustomerByBillTypeId(int billTypeId)
        {
            var data = await _context.CustomerInfos.Include(x => x.billType).Where(x => x.billTypeId == billTypeId).AsNoTracking().ToListAsync();

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
        public async Task<IEnumerable<BillInfo>> GetCustomerBills(int customerId)
        {
            var data = await _context.BillInfos.Where(x => x.customerId == customerId).Include(x => x.customer).Include(x => x.customer.billType).OrderBy(x => x.generateDate).AsNoTracking().ToListAsync();

            return data;
        }
        public async Task<BillInfo> UpdatePaid(int id)
        {
            var data = await _context.BillInfos.Include(x => x.customer).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            data.status = 1;
            data.paymentDate = DateTime.Now;

            _context.BillInfos.Update(data);

            await _context.SaveChangesAsync();

            return data;
        }
        public async Task<BillInfo> CancelPayment(int id)
        {
            var data = await _context.BillInfos.Include(x => x.customer).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            data.status = 0;
            data.paymentDate = null;

            _context.BillInfos.Update(data);

            await _context.SaveChangesAsync();
            
            return data;
        }
    }
}
