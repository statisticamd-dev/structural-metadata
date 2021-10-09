using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Presentation.Persistence.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepresentedVariableValueDomains",
                schema: "iais-structural");

            migrationBuilder.EnsureSchema(
                name: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Variables",
                schema: "iais-structural",
                newName: "Variables",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "ValueDomains",
                schema: "iais-structural",
                newName: "ValueDomains",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "UnitTypes",
                schema: "iais-structural",
                newName: "UnitTypes",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "RepresentedVariables",
                schema: "iais-structural",
                newName: "RepresentedVariables",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "NodeSets",
                schema: "iais-structural",
                newName: "NodeSets",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Nodes",
                schema: "iais-structural",
                newName: "Nodes",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                schema: "iais-structural",
                newName: "MeasurementUnits",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "MeasurementTypes",
                schema: "iais-structural",
                newName: "MeasurementTypes",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Mappings",
                schema: "iais-structural",
                newName: "Mappings",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Levels",
                schema: "iais-structural",
                newName: "Levels",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Labels",
                schema: "iais-structural",
                newName: "Labels",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Correspondences",
                schema: "iais-structural",
                newName: "Correspondences",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "iais-structural",
                newName: "Categories",
                newSchema: "iais_structural");

            migrationBuilder.AddColumn<string>(
                name: "Scope",
                schema: "iais_structural",
                table: "ValueDomains",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SubstantiveValueDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SubstantiveValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId1",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "Scope",
                schema: "iais_structural",
                table: "ValueDomains");

            migrationBuilder.DropColumn(
                name: "SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.EnsureSchema(
                name: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Variables",
                schema: "iais_structural",
                newName: "Variables",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "ValueDomains",
                schema: "iais_structural",
                newName: "ValueDomains",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "UnitTypes",
                schema: "iais_structural",
                newName: "UnitTypes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "RepresentedVariables",
                schema: "iais_structural",
                newName: "RepresentedVariables",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "NodeSets",
                schema: "iais_structural",
                newName: "NodeSets",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Nodes",
                schema: "iais_structural",
                newName: "Nodes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                schema: "iais_structural",
                newName: "MeasurementUnits",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "MeasurementTypes",
                schema: "iais_structural",
                newName: "MeasurementTypes",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Mappings",
                schema: "iais_structural",
                newName: "Mappings",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Levels",
                schema: "iais_structural",
                newName: "Levels",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Labels",
                schema: "iais_structural",
                newName: "Labels",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Correspondences",
                schema: "iais_structural",
                newName: "Correspondences",
                newSchema: "iais-structural");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "iais_structural",
                newName: "Categories",
                newSchema: "iais-structural");

            migrationBuilder.CreateTable(
                name: "RepresentedVariableValueDomains",
                schema: "iais-structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    RepresentedVariableId = table.Column<long>(type: "bigint", nullable: false),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    ValueDomainId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentedVariableValueDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentedVariableValueDomains_RepresentedVariables_Repres~",
                        column: x => x.RepresentedVariableId,
                        principalSchema: "iais-structural",
                        principalTable: "RepresentedVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentedVariableValueDomains_ValueDomains_ValueDomainId",
                        column: x => x.ValueDomainId,
                        principalSchema: "iais-structural",
                        principalTable: "ValueDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Scope",
                schema: "iais-structural",
                table: "RepresentedVariableValueDomains",
                columns: new[] { "RepresentedVariableId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_ValueDomainId",
                schema: "iais-structural",
                table: "RepresentedVariableValueDomains",
                column: "ValueDomainId");
        }
    }
}
