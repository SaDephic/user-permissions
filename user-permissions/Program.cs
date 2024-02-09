using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using user_permissions;

var builder = WebApplication.CreateBuilder(args);
//add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*namespace user_permissions.Constant
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Add",
                $"Permissions.{module}.Read",
                $"Permissions.{module}.Manager_Read",
                $"Permissions.{module}.HealthCheck_Read",
                $"Permissions.{module}.HealthCheck_Manager_Read",
            };
        }

        public static class Products
        {
            public const string Add = "PERM_USER_ROLE_ADD";
            public const string Read = "PERM_ABSENCE_READ";
            public const string Manager_Read = "PERM_ABSENCE_MANAGER_READ";
            public const string HealthCheck_Add = "PERM_HEALTHCHECK_ADD";
            public const string HealthCheck_Manager_Read = "PERM_HEALTHCHECK_MANAGER_READ";
        }
    }
}

namespace user_permissions.Constant
{
    public enum Roles
    {
        EMPLOYEE,
        MANAGER,
        HRPARTNER,
        HRDEV,
        SUPERUSER
    }
}*/


