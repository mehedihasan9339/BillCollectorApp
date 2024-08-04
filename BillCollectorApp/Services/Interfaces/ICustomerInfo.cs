using BillCollectorApp.Data.Customer;

namespace BillCollectorApp.Services.Interfaces
{
    public interface ICustomerInfo
    {
        Task<int> SaveCustomer(CustomerInfo model);
        Task<CustomerInfo> GetCustomerById(int id);
        Task<IEnumerable<CustomerInfo>> GetCustomers();
        Task<int> RemoveCustomer(int id);
    }
}
