using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCourse.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTableWithFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesTable",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    EmployeeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTable", x => x.EmpId);
                    table.CheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40");
                    table.CheckConstraint("Check_Employee_Email", "[Email] Like '%@%.%'");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesTable");
        }
    }
}
