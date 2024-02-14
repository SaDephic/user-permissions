using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using user_permissions.Custom;

namespace user_permissions
{
    public class DataContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //parse table user-permission https://docs.google.com/document/d/18PbWWj57ERwNVOLKRe0RZb46ws7IxuYrOqmEJcIRgOg/edit#heading=h.w3lo0zm8p1l4
            //https://docs.google.com/spreadsheets/d/1uMwlYOFgSx1kPd23m1wvgFn-zUtDVQPcsjtsb0iIwuw/edit#gid=0 parsed

            /*PermFromXML d = new PermFromXML();
            modelBuilder.Entity<UserPermissions>().HasData(
                d.permissions
            );

            modelBuilder.Entity<UserRole>().HasData(
                d.roles
            );*/
        }
    }
}
