using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace user_permissions.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "employee");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "hrdev");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "hrpartner");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "manager");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "superuser");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3000");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3001");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3002");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "1", "etna", "hrpartner" },
                    { "10", "alius29", "employee" },
                    { "11", "nymeria", "hrpartner" },
                    { "12", "wezen", "manager" },
                    { "13", "oqaris", "employee" },
                    { "14", "kurs", "employee" },
                    { "15", "gigachad", "employee" },
                    { "16", "frogmonarch", "hrdev" },
                    { "17", "fox", "hrpartner" },
                    { "18", "distortion", "hrpartner" },
                    { "19", "degree", "employee" },
                    { "2", "manager", "employee" },
                    { "20", "resolute", "manager" },
                    { "3", "kortex", "manager" },
                    { "3000", "djaz", "superuser" },
                    { "3001", "kazurus", "manager" },
                    { "3002", "nomad", "employee" },
                    { "4", "b3n", "manager" },
                    { "5", "sempai", "hrdev" },
                    { "6", "kojima", "hrpartner" },
                    { "7", "asimar", "employee" },
                    { "8", "invasion", "employee" },
                    { "9", "holix", "employee" }
                });
        }
    }
}
