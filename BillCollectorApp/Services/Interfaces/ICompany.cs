using BillCollectorApp.Data.MasterData;

namespace BillCollectorApp.Services.Interfaces
{
    public interface ICompany
    {
        Task<int> SaveCompany(Company model);
        Task<Company> GetCompanyById(int id);
        Task<IEnumerable<Company>> GetCompanies();
        Task<int> RemoveCompany(int id);
    }
}
