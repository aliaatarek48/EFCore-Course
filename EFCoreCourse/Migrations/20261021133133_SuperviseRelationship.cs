using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCourse.Migrations
{
    /// <inheritdoc />
    public partial class SuperviseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "EmployeesTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_SupervisorId",
                table: "EmployeesTable",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_EmployeesTable_SupervisorId",
                table: "EmployeesTable",
                column: "SupervisorId",
                principalTable: "EmployeesTable",
                principalColumn: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_EmployeesTable_SupervisorId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_SupervisorId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "EmployeesTable");
        }
    }
}
