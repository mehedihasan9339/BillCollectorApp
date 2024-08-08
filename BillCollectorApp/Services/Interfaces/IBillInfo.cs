using BillCollectorApp.Data.Bill;

namespace BillCollectorApp.Services.Interfaces
{
    public interface IBillInfo
    {
        Task<int> SaveBillInfo(BillInfo model);
        Task<int> SaveBillInfos(List<BillInfo> models);
        Task<BillInfo> GetBillInfoById(int id);
        Task<IEnumerable<BillInfo>> GetBills();
        Task<int> RemoveBill(int id);
        Task<IEnumerable<BillInfo>> GetBills(int billTypeId, int year, string month);
        Task<int> UpdateBill(int id, decimal? bill);
    }
}
