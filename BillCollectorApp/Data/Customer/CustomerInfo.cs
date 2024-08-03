using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Data.Customer
{
    public class CustomerInfo:Base
    {
        public string code { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int status { get; set; } = 1;

        public int companyId { get; set; }
        public Company company { get; set; }
    }
}
