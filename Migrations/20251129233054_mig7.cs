using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceBuddy.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Inspections",
                newName: "Vin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vin",
                table: "Inspections",
                newName: "VehicleId");
        }
    }
}
