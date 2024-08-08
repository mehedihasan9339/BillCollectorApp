using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.Customer;

namespace BillCollectorApp.Services.Interfaces
{
    public interface ICustomerInfo
    {
        Task<int> SaveCustomer(CustomerInfo model);
        Task<CustomerInfo> GetCustomerById(int id);
        Task<IEnumerable<CustomerInfo>> GetCustomerByBillTypeId(int billTypeId);
        Task<IEnumerable<CustomerInfo>> GetCustomers();
        Task<int> RemoveCustomer(int id);
        Task<IEnumerable<BillInfo>> GetCustomerBills(int customerId);
        Task<BillInfo> UpdatePaid(int id);
        Task<BillInfo> CancelPayment(int id);
    }
}
