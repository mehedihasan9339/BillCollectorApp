using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Models
{
    public class GenerateBillVm
    {
        public int billTypeId { get; set; }
        public int year { get; set; }
        public string month { get; set; }
        public decimal? amount { get; set; }

        public IEnumerable<BillType> BillTypes { get; set; }
    }
}
