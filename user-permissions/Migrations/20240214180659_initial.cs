using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace user_permissions.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    UserRole = table.Column<string>(type: "text", nullable: false),
                    Permissions = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.UserRole);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserLogin = table.Column<string>(type: "text", nullable: false),
                    _UserRole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "UserRole", "Permissions" },
                values: new object[,]
                {
                    { "employee", new List<string>() },
                    { "hrdev", new List<string> { "PERM_ABSENCE_READ", "PERM_MYDEPARTMENTS_READ", "PERM_GOALS_READ" } },
                    { "hrpartner", new List<string> { "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_FULL", "PERM_MYDEPARTMENTS_READ", "PERM_GOALS_READ", "PERM_ONBOARDING_READ", "PERM_EQUIPMENT_READ", "PERM_TRANSITIONS_READ" } },
                    { "manager", new List<string> { "PERM_ABSENCE_MANAGER_READ", "PERM_HEALTHCHECK_MANAGER_READ", "PERM_MYDEPARTMENTS_MANAGER_READ", "PERM_TASK_SUBJECT_MANAGER_ADD", "PERM_TASK_PERF_MANAGER_ADD", "PERM_TASK_WATCHER_ADD", "PERM_GOALS_MANAGER_READ", "PERM_ONBOARDING_MANAGER_READ", "PERM_EQUIPMENT_MANAGER_READ", "PERM_TRANSITIONS_MANAGER_READ" } },
                    { "superuser", new List<string> { "PERM_USER_ROLE_ADD", "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_FULL", "PERM_MYDEPARTMENTS_READ", "PERM_TASK_FULL", "PERM_GOALS_READ", "PERM_ONBOARDING_READ", "PERM_EQUIPMENT_READ", "PERM_TRANSITIONS_READ" } }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "UserLogin", "_UserRole" },
                values: new object[,]
                {
                    { "1", "etna", "hrdev" },
                    { "10", "alius29", "employee" },
                    { "11", "nymeria", "employee" },
                    { "12", "wezen", "hrpartner" },
                    { "13", "oqaris", "hrpartner" },
                    { "14", "kurs", "hrpartner" },
                    { "15", "gigachad", "manager" },
                    { "16", "frogmonarch", "hrpartner" },
                    { "17", "fox", "employee" },
                    { "18", "distortion", "employee" },
                    { "19", "degree", "manager" },
                    { "2", "manager", "manager" },
                    { "20", "resolute", "hrpartner" },
                    { "3", "kortex", "employee" },
                    { "3000", "djaz", "superuser" },
                    { "3001", "kazurus", "manager" },
                    { "3002", "nomad", "employee" },
                    { "4", "b3n", "employee" },
                    { "5", "sempai", "hrpartner" },
                    { "6", "kojima", "employee" },
                    { "7", "asimar", "hrpartner" },
                    { "8", "invasion", "employee" },
                    { "9", "holix", "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
