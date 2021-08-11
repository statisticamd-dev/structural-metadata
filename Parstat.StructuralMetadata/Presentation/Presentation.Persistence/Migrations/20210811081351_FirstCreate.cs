using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Presentation.Persistence.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value_En = table.Column<string>(type: "text", nullable: true),
                    Value_Ro = table.Column<string>(type: "text", nullable: true),
                    Value_Ru = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
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
                    VersionRationale_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NodeSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeSetType = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_NodeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
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
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
                    ConvertionRule = table.Column<string>(type: "text", nullable: true),
                    MeasurementTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsStandard = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementUnits_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Correspondences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correspondences_NodeSets_SourceId",
                        column: x => x.SourceId,
                        principalTable: "NodeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correspondences_NodeSets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "NodeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelNumber = table.Column<int>(type: "integer", nullable: false),
                    NodeSetId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_NodeSets_NodeSetId",
                        column: x => x.NodeSetId,
                        principalTable: "NodeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MeasuresId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_UnitTypes_MeasuresId",
                        column: x => x.MeasuresId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeSetId = table.Column<long>(type: "bigint", nullable: false),
                    LevelId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    AggregationType = table.Column<string>(type: "text", nullable: false),
                    LabelId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nodes_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_NodeSets_NodeSetId",
                        column: x => x.NodeSetId,
                        principalTable: "NodeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueDomains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    Expression = table.Column<string>(type: "text", nullable: true),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    LevelId = table.Column<long>(type: "bigint", nullable: true),
                    NodeSetId = table.Column<long>(type: "bigint", nullable: true),
                    MeasurementUnitId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_ValueDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueDomains_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValueDomains_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValueDomains_NodeSets_NodeSetId",
                        column: x => x.NodeSetId,
                        principalTable: "NodeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepresentedVariables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VariableId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RepresentedVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentedVariables_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mappings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CorrespondenceId = table.Column<long>(type: "bigint", nullable: false),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mappings_Correspondences_CorrespondenceId",
                        column: x => x.CorrespondenceId,
                        principalTable: "Correspondences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mappings_Nodes_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mappings_Nodes_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentedVariableValueDomains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    RepresentedVariableId = table.Column<long>(type: "bigint", nullable: false),
                    ValueDomainId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentedVariableValueDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentedVariableValueDomains_RepresentedVariables_Repres~",
                        column: x => x.RepresentedVariableId,
                        principalTable: "RepresentedVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentedVariableValueDomains_ValueDomains_ValueDomainId",
                        column: x => x.ValueDomainId,
                        principalTable: "ValueDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LocalId_Version",
                table: "Categories",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Correspondences_SourceId_TargetId",
                table: "Correspondences",
                columns: new[] { "SourceId", "TargetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Correspondences_TargetId",
                table: "Correspondences",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LocalId_Version",
                table: "Levels",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Levels_NodeSetId",
                table: "Levels",
                column: "NodeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_CorrespondenceId",
                table: "Mappings",
                column: "CorrespondenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_SourceId_TargetId_CorrespondenceId",
                table: "Mappings",
                columns: new[] { "SourceId", "TargetId", "CorrespondenceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_TargetId",
                table: "Mappings",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementTypes_LocalId_Version",
                table: "MeasurementTypes",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_LocalId_Version",
                table: "MeasurementUnits",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_MeasurementTypeId",
                table: "MeasurementUnits",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_CategoryId",
                table: "Nodes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_Code_NodeSetId",
                table: "Nodes",
                columns: new[] { "Code", "NodeSetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_LabelId",
                table: "Nodes",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_LevelId",
                table: "Nodes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeSetId",
                table: "Nodes",
                column: "NodeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeSets_LocalId_Version",
                table: "NodeSets",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_LocalId_Version",
                table: "RepresentedVariables",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariables_VariableId",
                table: "RepresentedVariables",
                column: "VariableId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_RepresentedVariableId_Scope",
                table: "RepresentedVariableValueDomains",
                columns: new[] { "RepresentedVariableId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentedVariableValueDomains_ValueDomainId",
                table: "RepresentedVariableValueDomains",
                column: "ValueDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTypes_LocalId_Version",
                table: "UnitTypes",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValueDomains_LevelId",
                table: "ValueDomains",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueDomains_LocalId_Version",
                table: "ValueDomains",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValueDomains_MeasurementUnitId",
                table: "ValueDomains",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueDomains_NodeSetId",
                table: "ValueDomains",
                column: "NodeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_LocalId_Version",
                table: "Variables",
                columns: new[] { "LocalId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variables_MeasuresId",
                table: "Variables",
                column: "MeasuresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mappings");

            migrationBuilder.DropTable(
                name: "RepresentedVariableValueDomains");

            migrationBuilder.DropTable(
                name: "Correspondences");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "RepresentedVariables");

            migrationBuilder.DropTable(
                name: "ValueDomains");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "NodeSets");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");
        }
    }
}
