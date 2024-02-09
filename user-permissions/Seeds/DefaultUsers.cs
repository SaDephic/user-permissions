using Microsoft.AspNetCore.Identity;
using user_permissions.Constant;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace user_permissions.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "superuser"
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "superuser");

                    //EMPLOYEE
                    //MANAGER
                    //HRPARTNER
                    //HRDEV
                    //SUPERUSER

                    await userManager.AddToRoleAsync(defaultUser, Roles.EMPLOYEE.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.MANAGER.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.HRPARTNER.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.HRDEV.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SUPERUSER.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Products");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}