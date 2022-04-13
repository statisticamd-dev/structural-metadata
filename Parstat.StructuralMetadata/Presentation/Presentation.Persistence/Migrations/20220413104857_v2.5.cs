using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Presentation.Persistence.Migrations
{
    public partial class v25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityTag_Tag_TagId",
                schema: "iais_structural",
                table: "EntityTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Tag_ParentId",
                schema: "iais_structural",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                schema: "iais_structural",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityTag",
                schema: "iais_structural",
                table: "EntityTag");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "iais_structural",
                newName: "Tags",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "EntityTag",
                schema: "iais_structural",
                newName: "EntityTags",
                newSchema: "iais_structural");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ParentId",
                schema: "iais_structural",
                table: "Tags",
                newName: "IX_Tags_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTag_TagId",
                schema: "iais_structural",
                table: "EntityTags",
                newName: "IX_EntityTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTag_EntityId_EntityType_TagId",
                schema: "iais_structural",
                table: "EntityTags",
                newName: "IX_EntityTags_EntityId_EntityType_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                schema: "iais_structural",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityTags",
                schema: "iais_structural",
                table: "EntityTags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DataStructures",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: true),
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
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataStructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    RepresentedVariableId = table.Column<long>(type: "bigint", nullable: false),
                    DataStructureId = table.Column<long>(type: "bigint", nullable: false),
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
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_DataStructures_DataStructureId",
                        column: x => x.DataStructureId,
                        principalSchema: "iais_structural",
                        principalTable: "DataStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_RepresentedVariables_RepresentedVariableId",
                        column: x => x.RepresentedVariableId,
                        principalSchema: "iais_structural",
                        principalTable: "RepresentedVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ReportingBegin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReportingEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StatisticalProgramId = table.Column<long>(type: "bigint", nullable: false),
                    Connection = table.Column<string>(type: "text", nullable: true),
                    FilterExpression = table.Column<string>(type: "text", nullable: true),
                    StructureId = table.Column<long>(type: "bigint", nullable: false),
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
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSets_DataStructures_StructureId",
                        column: x => x.StructureId,
                        principalSchema: "iais_structural",
                        principalTable: "DataStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogicalRecords",
                schema: "iais_structural",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    UnitTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DataStructureId = table.Column<long>(type: "bigint", nullable: false),
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
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogicalRecords_DataStructures_DataStructureId",
                        column: x => x.DataStructureId,
                        principalSchema: "iais_structural",
                        principalTable: "DataStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogicalRecords_LogicalRecords_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "iais_structural",
                        principalTable: "LogicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogicalRecords_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalSchema: "iais_structural",
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentLogicalRecord",
                schema: "iais_structural",
                columns: table => new
                {
                    ComponentsId = table.Column<long>(type: "bigint", nullable: false),
                    RecordsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentLogicalRecord", x => new { x.ComponentsId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_ComponentLogicalRecord_Components_ComponentsId",
                        column: x => x.ComponentsId,
                        principalSchema: "iais_structural",
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentLogicalRecord_LogicalRecords_RecordsId",
                        column: x => x.RecordsId,
                        principalSchema: "iais_structural",
                        principalTable: "LogicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentLogicalRecord_RecordsId",
                schema: "iais_structural",
                table: "ComponentLogicalRecord",
                column: "RecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_DataStructureId",
                schema: "iais_structural",
                table: "Components",
                column: "DataStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_LocalId_Version",
                schema: "iais_structural",
                table: "Components",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_RepresentedVariableId",
                schema: "iais_structural",
                table: "Components",
                column: "RepresentedVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_LocalId_Version",
                schema: "iais_structural",
                table: "DataSets",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_StructureId",
                schema: "iais_structural",
                table: "DataSets",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_DataStructures_LocalId_Version",
                schema: "iais_structural",
                table: "DataStructures",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_DataStructureId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "DataStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_LocalId_Version",
                schema: "iais_structural",
                table: "LogicalRecords",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_ParentId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalRecords_UnitTypeId",
                schema: "iais_structural",
                table: "LogicalRecords",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityTags_Tags_TagId",
                schema: "iais_structural",
                table: "EntityTags",
                column: "TagId",
                principalSchema: "iais_structural",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_ParentId",
                schema: "iais_structural",
                table: "Tags",
                column: "ParentId",
                principalSchema: "iais_structural",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityTags_Tags_TagId",
                schema: "iais_structural",
                table: "EntityTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_ParentId",
                schema: "iais_structural",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "ComponentLogicalRecord",
                schema: "iais_structural");

            migrationBuilder.DropTable(
                name: "DataSets",
                schema: "iais_structural");

            migrationBuilder.DropTable(
                name: "Components",
                schema: "iais_structural");

            migrationBuilder.DropTable(
                name: "LogicalRecords",
                schema: "iais_structural");

            migrationBuilder.DropTable(
                name: "DataStructures",
                schema: "iais_structural");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                schema: "iais_structural",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityTags",
                schema: "iais_structural",
                table: "EntityTags");

            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "iais_structural",
                newName: "Tag",
                newSchema: "iais_structural");

            migrationBuilder.RenameTable(
                name: "EntityTags",
                schema: "iais_structural",
                newName: "EntityTag",
                newSchema: "iais_structural");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ParentId",
                schema: "iais_structural",
                table: "Tag",
                newName: "IX_Tag_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTags_TagId",
                schema: "iais_structural",
                table: "EntityTag",
                newName: "IX_EntityTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTags_EntityId_EntityType_TagId",
                schema: "iais_structural",
                table: "EntityTag",
                newName: "IX_EntityTag_EntityId_EntityType_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                schema: "iais_structural",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityTag",
                schema: "iais_structural",
                table: "EntityTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityTag_Tag_TagId",
                schema: "iais_structural",
                table: "EntityTag",
                column: "TagId",
                principalSchema: "iais_structural",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Tag_ParentId",
                schema: "iais_structural",
                table: "Tag",
                column: "ParentId",
                principalSchema: "iais_structural",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
