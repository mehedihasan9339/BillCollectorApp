using Microsoft.AspNetCore.Identity;

namespace BillCollectorApp.Data
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName)
        {

        }

    }
}
