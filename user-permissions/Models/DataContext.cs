using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;

namespace user_permissions.Models
{
    public class DataContext : DbContext
    {
        public DbSet<UserRole> Users { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Database=postgres");
    }
}
