using Microsoft.AspNetCore.Identity;
using user_permissions.Constant;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsyncSuperUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //EMPLOYEE
            //MANAGER
            //HRPARTNER
            //HRDEV
            //SUPERUSER

            await roleManager.CreateAsync(new IdentityRole(Roles.EMPLOYEE.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.MANAGER.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.HRPARTNER.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.HRDEV.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SUPERUSER.ToString()));
        }
    }
}