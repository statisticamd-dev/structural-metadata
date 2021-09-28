using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scope",
                table: "ValueDomains");

            migrationBuilder.EnsureSchema(
                name: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Variables",
                newName: "Variables",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "ValueDomains",
                newName: "ValueDomains",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "UnitTypes",
                newName: "UnitTypes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "RepresentedVariableValueDomains",
                newName: "RepresentedVariableValueDomains",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "RepresentedVariables",
                newName: "RepresentedVariables",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "NodeSets",
                newName: "NodeSets",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Nodes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                newName: "MeasurementUnits",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "MeasurementTypes",
                newName: "MeasurementTypes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Mappings",
                newName: "Mappings",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Levels",
                newName: "Levels",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Labels",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Correspondences",
                newName: "Correspondences",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "iais-structural");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Variables",
                schema: "iais-structural",
                newName: "Variables");

            migrationBuilder.RenameTable(
                name: "ValueDomains",
                schema: "iais-structural",
                newName: "ValueDomains");

            migrationBuilder.RenameTable(
                name: "UnitTypes",
                schema: "iais-structural",
                newName: "UnitTypes");

            migrationBuilder.RenameTable(
                name: "RepresentedVariableValueDomains",
                schema: "iais-structural",
                newName: "RepresentedVariableValueDomains");

            migrationBuilder.RenameTable(
                name: "RepresentedVariables",
                schema: "iais-structural",
                newName: "RepresentedVariables");

            migrationBuilder.RenameTable(
                name: "NodeSets",
                schema: "iais-structural",
                newName: "NodeSets");

            migrationBuilder.RenameTable(
                name: "Nodes",
                schema: "iais-structural",
                newName: "Nodes");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                schema: "iais-structural",
                newName: "MeasurementUnits");

            migrationBuilder.RenameTable(
                name: "MeasurementTypes",
                schema: "iais-structural",
                newName: "MeasurementTypes");

            migrationBuilder.RenameTable(
                name: "Mappings",
                schema: "iais-structural",
                newName: "Mappings");

            migrationBuilder.RenameTable(
                name: "Levels",
                schema: "iais-structural",
                newName: "Levels");

            migrationBuilder.RenameTable(
                name: "Labels",
                schema: "iais-structural",
                newName: "Labels");

            migrationBuilder.RenameTable(
                name: "Correspondences",
                schema: "iais-structural",
                newName: "Correspondences");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "iais-structural",
                newName: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Scope",
                table: "ValueDomains",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
