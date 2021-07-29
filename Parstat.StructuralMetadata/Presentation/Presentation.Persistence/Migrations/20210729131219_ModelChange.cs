using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementUnits_ValueDomains_StandardId",
                table: "MeasurementUnits");

            migrationBuilder.RenameColumn(
                name: "StandardId",
                table: "MeasurementUnits",
                newName: "MeasurementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MeasurementUnits_StandardId",
                table: "MeasurementUnits",
                newName: "IX_MeasurementUnits_MeasurementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                table: "MeasurementUnits",
                column: "MeasurementTypeId",
                principalTable: "MeasurementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                table: "MeasurementUnits");

            migrationBuilder.RenameColumn(
                name: "MeasurementTypeId",
                table: "MeasurementUnits",
                newName: "StandardId");

            migrationBuilder.RenameIndex(
                name: "IX_MeasurementUnits_MeasurementTypeId",
                table: "MeasurementUnits",
                newName: "IX_MeasurementUnits_StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementUnits_ValueDomains_StandardId",
                table: "MeasurementUnits",
                column: "StandardId",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
