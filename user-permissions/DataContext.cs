using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace user_permissions
{
    public class DataContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }

        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermissions>().HasData(
                new UserPermissions { UserRole = "MANAGER", Permissions = new List<string> { "PERM_ABSENCE_MANAGER_READ", "PERM_HEALTHCHECK_MANAGER_READ", "PERM_MYDEPARTMENTS_MANAGER_READ" } },
                new UserPermissions { UserRole = "HRPARTNER", Permissions = new List<string> { "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_ADD", "PERM_MYDEPARTMENTS_READ" } },
                new UserPermissions { UserRole = "HRDEV", Permissions = new List<string> { "PERM_ABSENCE_READ", "PERM_MYDEPARTMENTS_READ" } },
                new UserPermissions { UserRole = "SUPERUSER", Permissions = new List<string> { "PERM_USER_ROLE_ADD", "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_ADD", "PERM_MYDEPARTMENTS_READ" } }
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = "1", UserLogin = "Anna", _UserRole = "MANAGER"},
                new UserRole { Id = "2", UserLogin = "Denis", _UserRole = "HRPARTNER",},
                new UserRole { Id = "3", UserLogin = "Oleg", _UserRole =  "HRDEV",},
                new UserRole { Id = "4", UserLogin = "Roman", _UserRole =  "SUPERUSER"}
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration["DB_STRING"]);
        }
    }
}
