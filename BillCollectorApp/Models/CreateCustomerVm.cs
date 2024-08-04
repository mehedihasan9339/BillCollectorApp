using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Models
{
    public class CreateCustomerVm
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int status { get; set; } = 1;

        public int companyId { get; set; }

        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<CustomerInfo> Customers { get; set; }
    }
}
