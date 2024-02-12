using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace user_permissions
{
    public class DataContext : DbContext
    {
        public DbSet<UsersRoleList> UserRoles { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermissions>().HasData(
                    new UserPermissions{UserRole = "MANAGER", Permissions = {"1","2","3"}},
                    new UserPermissions{UserRole = "HRPARTNER", Permissions = {"1","2","3"}},
                    new UserPermissions{UserRole = "HRDEV", Permissions = {"1","2","3"}},
                    new UserPermissions{UserRole = "SUPERUSER", Permissions = {"1","2","3"}}
            );
        }
    }
}
