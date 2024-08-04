using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Services.Interfaces
{
    public interface IBillType
    {
        Task<int> SaveBillType(BillType model);
        Task<BillType> GetBillTypeById(int id);
        Task<IEnumerable<BillType>> GetBillTypes();
        Task<int> RemoveBillType(int id);
    }
}
