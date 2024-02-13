using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;

namespace user_permissions
{
    public class DataContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermissions>().HasData(
                new UserPermissions //Сотрудник
                { 
                    UserRole = "EMPLOYEE", 
                    Permissions = new() 
                },
                new UserPermissions //Руководитель
                {
                    UserRole = "MANAGER",
                    Permissions = new List<string> {
                        "PERM_ABSENCE_MANAGER_READ",
                        "PERM_HEALTHCHECK_MANAGER_READ",
                        "PERM_MYDEPARTMENTS_MANAGER_READ",
                        "PERM_TASK_SUBJECT_MANAGER_ADD",
                        "PERM_TASK_PERF_MANAGER_ADD",
                        "PERM_TASK_WATCHER_ADD",
                        "PERM_GOALS_MANAGER_READ",
                        "PERM_ONBOARDING_MANAGER_READ",
                        "PERM_EQUIPMENT_MANAGER_READ",
                        "PERM_TRANSITIONS_MANAGER_READ" }
                },
                new UserPermissions //HR Партнер
                {
                    UserRole = "HRPARTNER",
                    Permissions = new List<string> {
                        "PERM_ABSENCE_READ",
                        "PERM_HEALTHCHECK_FULL",
                        "PERM_MYDEPARTMENTS_READ",
                        "PERM_GOALS_READ",
                        "PERM_ONBOARDING_READ",
                        "PERM_EQUIPMENT_READ",
                        "PERM_TRANSITIONS_READ" }
                },
                new UserPermissions //HR Развития и обучения
                {
                    UserRole = "HRDEV",
                    Permissions = new List<string> {
                        "PERM_ABSENCE_READ",
                        "PERM_MYDEPARTMENTS_READ",
                        "PERM_GOALS_READ" 
                    }
                },
                new UserPermissions //Суперпользователь
                {
                    UserRole = "SUPERUSER",
                    Permissions = new List<string> {
                        "PERM_USER_ROLE_ADD",
                        "PERM_ABSENCE_READ",
                        "PERM_HEALTHCHECK_FULL",
                        "PERM_MYDEPARTMENTS_READ",
                        "PERM_TASK_FULL",
                        "PERM_GOALS_READ",
                        "PERM_ONBOARDING_READ",
                        "PERM_EQUIPMENT_READ",
                        "PERM_TRANSITIONS_READ"
                    }
                }
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = "1", UserLogin = "employee", _UserRole = "EMPLOYEE" },
                new UserRole { Id = "2", UserLogin = "manager", _UserRole = "MANAGER" },
                new UserRole { Id = "3", UserLogin = "hrpartner", _UserRole = "HRPARTNER" },
                new UserRole { Id = "4", UserLogin = "hrdev", _UserRole = "HRDEV" },
                new UserRole { Id = "5", UserLogin = "superuser", _UserRole = "SUPERUSER" }
            );
        }
    }
}
