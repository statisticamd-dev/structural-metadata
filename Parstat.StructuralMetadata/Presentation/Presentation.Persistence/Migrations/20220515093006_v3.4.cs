using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttributeAttachmentLevel",
                schema: "iais_structural",
                table: "Components",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierRole",
                schema: "iais_structural",
                table: "Components",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttributeMandatory",
                schema: "iais_structural",
                table: "Components",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIdentifierComposite",
                schema: "iais_structural",
                table: "Components",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIdentifierUnique",
                schema: "iais_structural",
                table: "Components",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttributeAttachmentLevel",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "IdentifierRole",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "IsAttributeMandatory",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "IsIdentifierComposite",
                schema: "iais_structural",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "IsIdentifierUnique",
                schema: "iais_structural",
                table: "Components");
        }
    }
}
