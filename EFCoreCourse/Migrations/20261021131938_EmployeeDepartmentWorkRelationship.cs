using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCourse.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentWorkRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_DepartmentId",
                table: "EmployeesTable",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_Departments_DepartmentId",
                table: "EmployeesTable",
                column: "DepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_Departments_DepartmentId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_DepartmentId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmployeesTable");
        }
    }
}
