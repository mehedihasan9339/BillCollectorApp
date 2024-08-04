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
    }
}
