using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace user_permissions.Models
{
    public class DataContext : DbContext
    {
        public DbSet<UserRole> Users { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }

        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
