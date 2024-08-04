using BillCollectorApp.Context;
using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.MasterData;
using BillCollectorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillCollectorApp.Services
{
    public class BillTypeService:IBillType
    {
        public readonly ApplicationDbContext _context;

        public BillTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveBillType(BillType model)
        {
            if (model.Id > 0)
            {
                _context.BillTypes.Update(model);
            }
            else
            {
                _context.BillTypes.Add(model);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<BillType> GetBillTypeById(int id)
        {
            var data = await _context.BillTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return data;
        }

        public async Task<IEnumerable<BillType>> GetBillTypes()
        {
            var data = await _context.BillTypes.AsNoTracking().ToListAsync();

            return data;
        }

        public async Task<int> RemoveBillType(int id)
        {
            var data = await _context.BillTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            _context.BillTypes.Remove(data);

            return await _context.SaveChangesAsync();
        }
    }
}
