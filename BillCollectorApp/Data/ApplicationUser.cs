using BillCollectorApp.Data.MasterData;
using Microsoft.AspNetCore.Identity;

namespace BillCollectorApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int companyId { get; set; }
        public Company company { get; set; }
    }
}
