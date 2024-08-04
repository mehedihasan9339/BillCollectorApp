using BillCollectorApp.Data.Bill;

namespace BillCollectorApp.Services.Interfaces
{
    public interface IBillInfo
    {
        Task<int> SaveBillInfo(BillInfo model);
        Task<BillInfo> GetBillInfoById(int id);
        Task<IEnumerable<BillInfo>> GetBills();
        Task<int> RemoveBill(int id);
    }
}
