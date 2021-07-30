using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_SentinelValueDomainId",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "SentinelValueDomainId",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "SubstantiveValueDomainId",
                table: "RepresentedVariables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SentinelValueDomainId",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubstantiveValueDomainId",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_SentinelValueDomainId",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
