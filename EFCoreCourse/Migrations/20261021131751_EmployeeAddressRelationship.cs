using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCourse.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAddressRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_City",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Country",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Street",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpAddress_City",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Country",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Street",
                table: "EmployeesTable");
        }
    }
}
