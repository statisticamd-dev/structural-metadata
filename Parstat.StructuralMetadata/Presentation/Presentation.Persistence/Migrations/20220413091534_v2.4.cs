using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Presentation.Persistence.Migrations
{
    public partial class v24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_En",
                schema: "iais_structural",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_Ro",
                schema: "iais_structural",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_Ru",
                schema: "iais_structural",
                table: "Labels");

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_En = table.Column<string>(type: "text", nullable: true),
                    Name_Ro = table.Column<string>(type: "text", nullable: true),
                    Name_Ru = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Tag_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "iais_structural",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityTag",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "iais_structural",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_En_Value_Ro_Value_Ru",
                schema: "iais_structural",
                table: "Labels",
                columns: new[] { "Value_En", "Value_Ro", "Value_Ru" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityTag_EntityId_EntityType_TagId",
                schema: "iais_structural",
                table: "EntityTag",
                columns: new[] { "EntityId", "EntityType", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityTag_TagId",
                schema: "iais_structural",
                table: "EntityTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ParentId",
                schema: "iais_structural",
                table: "Tag",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityTag",
                schema: "iais_structural");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "iais_structural");

            migrationBuilder.DropIndex(
                name: "IX_Labels_Value_En_Value_Ro_Value_Ru",
                schema: "iais_structural",
                table: "Labels");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_En",
                schema: "iais_structural",
                table: "Labels",
                column: "Value_En",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_Ro",
                schema: "iais_structural",
                table: "Labels",
                column: "Value_Ro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Value_Ru",
                schema: "iais_structural",
                table: "Labels",
                column: "Value_Ru",
                unique: true);
        }
    }
}
