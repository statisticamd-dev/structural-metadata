using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class ModelChange10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValueDomains_NodeSets_NodeSetId",
                table: "ValueDomains");

            migrationBuilder.AlterColumn<long>(
                name: "NodeSetId",
                table: "ValueDomains",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ValueDomains_NodeSets_NodeSetId",
                table: "ValueDomains",
                column: "NodeSetId",
                principalTable: "NodeSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValueDomains_NodeSets_NodeSetId",
                table: "ValueDomains");

            migrationBuilder.AlterColumn<long>(
                name: "NodeSetId",
                table: "ValueDomains",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueDomains_NodeSets_NodeSetId",
                table: "ValueDomains",
                column: "NodeSetId",
                principalTable: "NodeSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
