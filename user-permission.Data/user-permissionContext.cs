using Microsoft.EntityFrameworkCore;
using user_permissions.Data;

namespace user_permission.Data
{
    public class user_permissionContext : DbContext
    {
        public user_permissionContext(DbContextOptions<user_permissionContext> options) :
            base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseSerialColumns();
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}

