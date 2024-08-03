namespace BillCollectorApp.Data.MasterData
{
    public class BillType:Base
    {
        public string code { get; set; }
        public string name { get; set; }
        public int status { get; set; } = 1;
    }
}
