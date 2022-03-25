using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits",
                column: "MeasurementTypeId",
                principalSchema: "iais_structural",
                principalTable: "MeasurementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                schema: "iais_structural",
                table: "MeasurementUnits",
                column: "MeasurementTypeId",
                principalSchema: "iais_structural",
                principalTable: "MeasurementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
