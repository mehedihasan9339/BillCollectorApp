namespace BillCollectorApp.Data.MasterData
{
    public class Company:Base
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
