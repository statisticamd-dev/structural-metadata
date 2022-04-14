using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Persistence.Migrations
{
    public partial class v28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogicalRecords_LogicalRecords_ParentId",
                schema: "iais_structural",
                table: "LogicalRecords");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                schema: "iais_structural",
                table: "LogicalRecords",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_LogicalRecords_LogicalRecords_ParentId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "ParentId",
                principalSchema: "iais_structural",
                principalTable: "LogicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogicalRecords_LogicalRecords_ParentId",
                schema: "iais_structural",
                table: "LogicalRecords");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                schema: "iais_structural",
                table: "LogicalRecords",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogicalRecords_LogicalRecords_ParentId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "ParentId",
                principalSchema: "iais_structural",
                principalTable: "LogicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
