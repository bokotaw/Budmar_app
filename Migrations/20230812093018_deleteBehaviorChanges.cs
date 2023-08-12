using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budmar_app.Migrations
{
    /// <inheritdoc />
    public partial class deleteBehaviorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractExpenses_Contracts_ContractId",
                table: "ContractExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Contracts_ContractId",
                table: "WorkHours");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Employees_EmployeeId",
                table: "WorkHours");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractExpenses_Contracts_ContractId",
                table: "ContractExpenses",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Contracts_ContractId",
                table: "WorkHours",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Employees_EmployeeId",
                table: "WorkHours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractExpenses_Contracts_ContractId",
                table: "ContractExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Contracts_ContractId",
                table: "WorkHours");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Employees_EmployeeId",
                table: "WorkHours");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractExpenses_Contracts_ContractId",
                table: "ContractExpenses",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Contracts_ContractId",
                table: "WorkHours",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Employees_EmployeeId",
                table: "WorkHours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
