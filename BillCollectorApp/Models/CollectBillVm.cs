using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Models
{
    public class CollectBillVm
    {
        public IEnumerable<BillType> BillTypes { get; set; }
        public IEnumerable<BillInfo> BillInfos { get; set; }
    }
}
