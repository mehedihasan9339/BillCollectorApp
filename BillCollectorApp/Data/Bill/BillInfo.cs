using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Data.Bill
{
    public class BillInfo:Base
    {
        public int customerId { get; set; }
        public CustomerInfo customer { get; set; }

        public DateTime? generateDate { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? paymentDate { get; set; }

        public decimal? bill { get; set; }
        public string month { get; set; }
        public int year { get; set; }
        public int status { get; set; } = 0;
        public string paymentMethod { get; set; } //Cash,bKash, Rocket, Bank
        public string trxNo { get; set; }
    }
}
