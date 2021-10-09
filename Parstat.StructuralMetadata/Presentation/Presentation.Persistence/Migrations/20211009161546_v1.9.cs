using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariables_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropColumn(
                name: "ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_ValueDomainId1",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "ValueDomainId1",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
