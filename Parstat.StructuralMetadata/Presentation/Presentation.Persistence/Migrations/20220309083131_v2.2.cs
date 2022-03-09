using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Concept",
                schema: "iais_structural",
                table: "Concept");

            migrationBuilder.RenameTable(
                name: "Concept",
                schema: "iais_structural",
                newName: "Concepts",
                newSchema: "iais_structural");

            migrationBuilder.RenameIndex(
                name: "IX_Concept_LocalId_Version",
                schema: "iais_structural",
                table: "Concepts",
                newName: "IX_Concepts_LocalId_Version");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concepts",
                schema: "iais_structural",
                table: "Concepts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Concepts",
                schema: "iais_structural",
                table: "Concepts");

            migrationBuilder.RenameTable(
                name: "Concepts",
                schema: "iais_structural",
                newName: "Concept",
                newSchema: "iais_structural");

            migrationBuilder.RenameIndex(
                name: "IX_Concepts_LocalId_Version",
                schema: "iais_structural",
                table: "Concept",
                newName: "IX_Concept_LocalId_Version");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concept",
                schema: "iais_structural",
                table: "Concept",
                column: "Id");
        }
    }
}
