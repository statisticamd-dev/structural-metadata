using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description_En",
                schema: "iais_structural",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ro",
                schema: "iais_structural",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ru",
                schema: "iais_structural",
                table: "Nodes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_En",
                schema: "iais_structural",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Description_Ro",
                schema: "iais_structural",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Description_Ru",
                schema: "iais_structural",
                table: "Nodes");
        }
    }
}
