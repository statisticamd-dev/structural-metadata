using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "iais_structural",
                table: "DataStructures",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "iais_structural",
                table: "DataStructures");
        }
    }
}
