using BillCollectorApp.Context;
using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.Customer;
using BillCollectorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillCollectorApp.Services
{
    public class BillInfoService:IBillInfo
    {
        public readonly ApplicationDbContext _context;

        public BillInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveBillInfo(BillInfo model)
        {
            if (model.Id > 0)
            {
                _context.BillInfos.Update(model);
            }
            else
            {
                _context.BillInfos.Add(model);
            }

            return await _context.SaveChangesAsync();
        }
        public async Task<int> SaveBillInfos(List<BillInfo> models)
        {
            if (models.Count > 0)
            {
                _context.BillInfos.AddRange(models);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<BillInfo> GetBillInfoById(int id)
        {
            var data = await _context.BillInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return data;
        }

        public async Task<IEnumerable<BillInfo>> GetBills()
        {
            var data = await _context.BillInfos.AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<int> RemoveBill(int id)
        {
            var data = await _context.BillInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            _context.BillInfos.Remove(data);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillInfo>> GetBills(int billTypeId, int year, string month)
        {
            var data = await _context.BillInfos.Include(x => x.customer).Include(x => x.customer.billType).Where(x => x.customer.billTypeId == billTypeId && x.month == month && x.year == year).AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<int> UpdateBill(int id, decimal? bill)
        {
            var data = await _context.BillInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            data.bill = bill;

            _context.BillInfos.Update(data);
            var res = await _context.SaveChangesAsync();

            return res;
        }
    }
}
