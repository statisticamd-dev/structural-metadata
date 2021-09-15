using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_En",
                table: "Labels",
                column: "Value_En",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_Ro",
                table: "Labels",
                column: "Value_Ro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_Ru",
                table: "Labels",
                column: "Value_Ru",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_En",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_Ro",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_Ru",
                table: "Labels");
        }
    }
}
