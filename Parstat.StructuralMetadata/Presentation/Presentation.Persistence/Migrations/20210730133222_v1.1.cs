using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Value~",
                table: "RepresentedVariableValueDomains");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Scope",
                table: "RepresentedVariableValueDomains",
                columns: new[] { "RepresentedVariableId", "Scope" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Scope",
                table: "RepresentedVariableValueDomains");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Value~",
                table: "RepresentedVariableValueDomains",
                columns: new[] { "RepresentedVariableId", "ValueDomainId", "Scope" },
                unique: true);
        }
    }
}
