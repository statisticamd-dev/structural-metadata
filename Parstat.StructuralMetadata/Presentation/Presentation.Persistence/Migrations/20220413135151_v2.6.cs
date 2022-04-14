using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExchangeChannel",
                schema: "iais_structural",
                table: "DataSets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExchangeDirection",
                schema: "iais_structural",
                table: "DataSets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeChannel",
                schema: "iais_structural",
                table: "DataSets");

            migrationBuilder.DropColumn(
                name: "ExchangeDirection",
                schema: "iais_structural",
                table: "DataSets");
        }
    }
}
