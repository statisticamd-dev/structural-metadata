using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LogicalRecords_DataStructureId",
                schema: "iais_structural",
                table: "LogicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_LogicalRecords_LocalId_Version",
                schema: "iais_structural",
                table: "LogicalRecords");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_DataStructureId_LocalId_Version",
                schema: "iais_structural",
                table: "LogicalRecords",
                columns: new[] { "DataStructureId", "LocalId", "Version" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LogicalRecords_DataStructureId_LocalId_Version",
                schema: "iais_structural",
                table: "LogicalRecords");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_DataStructureId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "DataStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_LocalId_Version",
                schema: "iais_structural",
                table: "LogicalRecords",
                columns: new[] { "LocalId", "Version" },
                unique: true);
        }
    }
}
