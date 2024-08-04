using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Models
{
    public class BillTypeVm
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int status { get; set; } = 1;

        public IEnumerable<BillType> BillTypes { get; set; }
    }
}
