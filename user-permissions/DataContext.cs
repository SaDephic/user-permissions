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
                    new UserPermissions{UserRole = "MANAGER", Permissions = new List<string> { "1", "2", "3" } },
                    new UserPermissions{UserRole = "HRPARTNER", Permissions = new List<string> { "1", "2", "3" } },
                    new UserPermissions{UserRole = "HRDEV", Permissions = new List<string> { "1", "2", "3" } },
                    new UserPermissions{UserRole = "SUPERUSER", Permissions = new List<string> { "1", "2", "3" } }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration["DB_STRING"]);
        }
    }
}
