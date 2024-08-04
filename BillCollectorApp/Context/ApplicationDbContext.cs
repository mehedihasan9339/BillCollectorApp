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



        public override int SaveChanges()
        {
            SetAuditProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditProperties()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is Base && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (Base)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.createdAt = DateTime.UtcNow;
                    entity.createdBy = GetCurrentUser();  // Replace with your method to get the current user
                }
                entity.updatedAt = DateTime.UtcNow;
                entity.updatedBy = GetCurrentUser();  // Replace with your method to get the current user
            }
        }

        private string GetCurrentUser()
        {
            // Replace this with your actual method to get the current user
            return "system";  // Example placeholder
        }
    }
}
