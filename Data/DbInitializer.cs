using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Cricks.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create roles
            var roles = new[] { "User", "Manager", "Admin", "Owner" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default Admin user
            var adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
            if (await userManager.FindByNameAsync(adminUser.UserName) == null)
            {
                await userManager.CreateAsync(adminUser, "Admin123#");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create default Owner user
            var ownerUser = new IdentityUser { UserName = "owner", Email = "owner@example.com" };
            if (await userManager.FindByNameAsync(ownerUser.UserName) == null)
            {
                await userManager.CreateAsync(ownerUser, "Owner123#");
                await userManager.AddToRoleAsync(ownerUser, "Owner");
            }
        }
    }
}
