using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace user_permissions.Migrations
{
    /// <inheritdoc />
    public partial class _100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "HRDEV",
                column: "Permissions",
                value: new List<string> { "PERM_ABSENCE_READ", "PERM_MYDEPARTMENTS_READ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "HRPARTNER",
                column: "Permissions",
                value: new List<string> { "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_ADD", "PERM_MYDEPARTMENTS_READ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "MANAGER",
                column: "Permissions",
                value: new List<string> { "PERM_ABSENCE_MANAGER_READ", "PERM_HEALTHCHECK_MANAGER_READ", "PERM_MYDEPARTMENTS_MANAGER_READ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "SUPERUSER",
                column: "Permissions",
                value: new List<string> { "PERM_USER_ROLE_ADD", "PERM_ABSENCE_READ", "PERM_HEALTHCHECK_ADD", "PERM_MYDEPARTMENTS_READ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "HRDEV",
                column: "Permissions",
                value: new List<string>());

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "HRPARTNER",
                column: "Permissions",
                value: new List<string>());

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "MANAGER",
                column: "Permissions",
                value: new List<string>());

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "UserRole",
                keyValue: "SUPERUSER",
                column: "Permissions",
                value: new List<string>());
        }
    }
}
