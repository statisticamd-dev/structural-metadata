using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Presentation.Persistence.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.CreateTable(
                name: "Concept",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LocalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name_En = table.Column<string>(type: "text", nullable: true),
                    Name_Ro = table.Column<string>(type: "text", nullable: true),
                    Name_Ru = table.Column<string>(type: "text", nullable: true),
                    Description_En = table.Column<string>(type: "text", nullable: true),
                    Description_Ro = table.Column<string>(type: "text", nullable: true),
                    Description_Ru = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VersionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VersionRationale_En = table.Column<string>(type: "text", nullable: true),
                    VersionRationale_Ro = table.Column<string>(type: "text", nullable: true),
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true),
                    Definition_En = table.Column<string>(type: "text", nullable: true),
                    Definition_Ro = table.Column<string>(type: "text", nullable: true),
                    Definition_Ru = table.Column<string>(type: "text", nullable: true),
                    Link_En = table.Column<string>(type: "text", nullable: true),
                    Link_Ro = table.Column<string>(type: "text", nullable: true),
                    Link_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concept", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concept_LocalId_Version",
                schema: "iais_structural",
                table: "Concept",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SubstantiveValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables");

            migrationBuilder.DropTable(
                name: "Concept",
                schema: "iais_structural");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SentinelValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SentinelValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentedVariables_ValueDomains_SubstantiveValueDomainId",
                schema: "iais_structural",
                table: "RepresentedVariables",
                column: "SubstantiveValueDomainId",
                principalSchema: "iais_structural",
                principalTable: "ValueDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
