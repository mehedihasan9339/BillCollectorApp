using BillCollectorApp.Data;
using BillCollectorApp.Data.Bill;
using BillCollectorApp.Data.Customer;
using BillCollectorApp.Data.MasterData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BillCollectorApp.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
            Database.SetCommandTimeout(500000);
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
    }
}
