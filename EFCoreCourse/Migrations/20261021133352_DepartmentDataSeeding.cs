using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCourse.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Departments",
                columns: new[] { "DeptId", "DateOfCreation", "DeptManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IT" },
                    { 2, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sales" },
                    { 3, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 3);
        }
    }
}
