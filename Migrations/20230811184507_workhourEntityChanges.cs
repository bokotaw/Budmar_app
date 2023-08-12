using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budmar_app.Migrations
{
    /// <inheritdoc />
    public partial class workhourEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseHourlyWage",
                table: "WorkHours",
                type: "decimal(19,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseHourlyWage",
                table: "WorkHours");
        }
    }
}
