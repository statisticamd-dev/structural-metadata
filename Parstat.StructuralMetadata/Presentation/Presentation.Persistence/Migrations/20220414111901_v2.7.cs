using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Components_DataStructureId",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_LocalId_Version",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.CreateIndex(
                name: "IX_Components_DataStructureId_LocalId_Version",
                schema: "iais_structural",
                table: "Components",
                columns: new[] { "DataStructureId", "LocalId", "Version" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Components_DataStructureId_LocalId_Version",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.CreateIndex(
                name: "IX_Components_DataStructureId",
                schema: "iais_structural",
                table: "Components",
                column: "DataStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_LocalId_Version",
                schema: "iais_structural",
                table: "Components",
                columns: new[] { "LocalId", "Version" },
                unique: true);
        }
    }
}
