using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WSPro.Backend.Migrations
{
    public partial class addCustomParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cranes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CanBeNull = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCustom = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelayCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    DelayCauseId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelayCauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelayCauses_DelayCauses_DelayCauseId",
                        column: x => x.DelayCauseId,
                        principalTable: "DelayCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherWorkOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CrewType = table.Column<string>(type: "text", nullable: false),
                    CrewWorkType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherWorkOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WebconCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    MetodologyCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CentralScheduleSync = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SupportedStatuses = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BimModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModelUrn = table.Column<string>(type: "text", nullable: false),
                    DefaultViewName = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BimModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BimModels_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomParamProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CustomParamsId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomParamProjects", x => new { x.CustomParamsId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_CustomParamProjects_CustomParams_CustomParamsId",
                        column: x => x.CustomParamsId,
                        principalTable: "CustomParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomParamProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vertical = table.Column<string>(type: "text", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedFinish = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedStartBP = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedFinishBP = table.Column<DateTime>(type: "date", nullable: true),
                    RealStart = table.Column<DateTime>(type: "date", nullable: true),
                    RealFinish = table.Column<DateTime>(type: "date", nullable: true),
                    CraneId = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTerms_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupTerms_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupTerms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CrewWorkType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commentary = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: true),
                    CraneId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delays_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Delays_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Delays_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrewWorkType = table.Column<string>(type: "text", nullable: true),
                    IsHouseWorker = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    WarbudId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BimModel_Cranes",
                columns: table => new
                {
                    CraneId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BimModel_Cranes", x => new { x.ModelId, x.CraneId });
                    table.ForeignKey(
                        name: "FK_BimModel_Cranes_BimModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BimModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BimModel_Cranes_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BimModel_Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BimModel_Levels", x => new { x.ModelId, x.LevelId });
                    table.ForeignKey(
                        name: "FK_BimModel_Levels_BimModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BimModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BimModel_Levels_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Area = table.Column<decimal>(type: "numeric", nullable: true),
                    Volume = table.Column<decimal>(type: "numeric", nullable: true),
                    RunningMetre = table.Column<decimal>(type: "numeric", nullable: true),
                    RevitId = table.Column<int>(type: "integer", nullable: false),
                    Vertical = table.Column<string>(type: "text", nullable: true),
                    RealisationMode = table.Column<string>(type: "text", nullable: true),
                    RotationDay = table.Column<int>(type: "integer", nullable: true),
                    LevelId = table.Column<int>(type: "integer", nullable: true),
                    CraneId = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    IsPrefabricated = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ElementTermId = table.Column<int>(type: "integer", nullable: true),
                    BimModelId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_BimModels_BimModelId",
                        column: x => x.BimModelId,
                        principalTable: "BimModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrewSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrewId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewSummaries_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewSummaries_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewSummaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementsTimeEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CrewId = table.Column<int>(type: "integer", nullable: false),
                    WorkedTime = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementsTimeEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementsTimeEvidences_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementsTimeEvidences_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementsTimeEvidences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupedOtherWorkTimeEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrewId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CrewType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupedOtherWorkTimeEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupedOtherWorkTimeEvidences_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupedOtherWorkTimeEvidences_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupedOtherWorkTimeEvidences_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delay_DelayCauses",
                columns: table => new
                {
                    DelayCauseId = table.Column<int>(type: "integer", nullable: false),
                    DelayId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delay_DelayCauses", x => new { x.DelayCauseId, x.DelayId });
                    table.ForeignKey(
                        name: "FK_Delay_DelayCauses_DelayCauses_DelayCauseId",
                        column: x => x.DelayCauseId,
                        principalTable: "DelayCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delay_DelayCauses_Delays_DelayId",
                        column: x => x.DelayId,
                        principalTable: "Delays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentaryElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentaryElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentaryElements_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentaryElements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomParamValues",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    CustomParamsId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomParamValues", x => new { x.CustomParamsId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_CustomParamValues_CustomParams_CustomParamsId",
                        column: x => x.CustomParamsId,
                        principalTable: "CustomParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomParamValues_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementStatuses_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementStatuses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementTerms",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedFinish = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedStartBP = table.Column<DateTime>(type: "date", nullable: true),
                    PlannedFinishBP = table.Column<DateTime>(type: "date", nullable: true),
                    RealStart = table.Column<DateTime>(type: "date", nullable: true),
                    RealFinish = table.Column<DateTime>(type: "date", nullable: true),
                    GroupTermId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTerms", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_ElementTerms_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementTerms_GroupTerms_GroupTermId",
                        column: x => x.GroupTermId,
                        principalTable: "GroupTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Worker_CrewSummaries",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "integer", nullable: false),
                    CrewSummaryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker_CrewSummaries", x => new { x.WorkerId, x.CrewSummaryId });
                    table.ForeignKey(
                        name: "FK_Worker_CrewSummaries_CrewSummaries_CrewSummaryId",
                        column: x => x.CrewSummaryId,
                        principalTable: "CrewSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worker_CrewSummaries_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerTimeEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WorkerId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    WorkedTime = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: false),
                    CrewSummaryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerTimeEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerTimeEvidences_CrewSummaries_CrewSummaryId",
                        column: x => x.CrewSummaryId,
                        principalTable: "CrewSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerTimeEvidences_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerTimeEvidences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerTimeEvidences_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Element_ElementsTimeEvidences",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    ElementsTimeEvidenceId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element_ElementsTimeEvidences", x => new { x.ElementId, x.ElementsTimeEvidenceId });
                    table.ForeignKey(
                        name: "FK_Element_ElementsTimeEvidences_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_ElementsTimeEvidences_ElementsTimeEvidences_Element~",
                        column: x => x.ElementsTimeEvidenceId,
                        principalTable: "ElementsTimeEvidences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherWorksTimeEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkedTime = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: false),
                    OtherWorkType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    OtherWorkOptionId = table.Column<int>(type: "integer", nullable: false),
                    GroupedOtherWorkTimeEvidenceId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherWorksTimeEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherWorksTimeEvidences_GroupedOtherWorkTimeEvidences_Group~",
                        column: x => x.GroupedOtherWorkTimeEvidenceId,
                        principalTable: "GroupedOtherWorkTimeEvidences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherWorksTimeEvidences_OtherWorkOptions_OtherWorkOptionId",
                        column: x => x.OtherWorkOptionId,
                        principalTable: "OtherWorkOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BimModel_Cranes_CraneId",
                table: "BimModel_Cranes",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_BimModel_Levels_LevelId",
                table: "BimModel_Levels",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_BimModels_ProjectId",
                table: "BimModels",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentaryElements_ElementId",
                table: "CommentaryElements",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentaryElements_UserId",
                table: "CommentaryElements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_ProjectId",
                table: "Crews",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_UserId",
                table: "Crews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummaries_CrewId",
                table: "CrewSummaries",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummaries_ProjectId",
                table: "CrewSummaries",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummaries_UserId",
                table: "CrewSummaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomParamProjects_ProjectId",
                table: "CustomParamProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomParamValues_ElementId",
                table: "CustomParamValues",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Delay_DelayCauses_DelayId",
                table: "Delay_DelayCauses",
                column: "DelayId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayCauses_DelayCauseId",
                table: "DelayCauses",
                column: "DelayCauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Delays_CraneId",
                table: "Delays",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Delays_LevelId",
                table: "Delays",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Delays_ProjectId",
                table: "Delays",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Delays_UserId",
                table: "Delays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ElementsTimeEvidences_ElementsTimeEvidenceId",
                table: "Element_ElementsTimeEvidences",
                column: "ElementsTimeEvidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_BimModelId",
                table: "Elements",
                column: "BimModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_CraneId",
                table: "Elements",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LevelId",
                table: "Elements",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatuses_ElementId",
                table: "ElementStatuses",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatuses_ProjectId",
                table: "ElementStatuses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatuses_UserId",
                table: "ElementStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsTimeEvidences_CrewId",
                table: "ElementsTimeEvidences",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsTimeEvidences_ProjectId",
                table: "ElementsTimeEvidences",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsTimeEvidences_UserId",
                table: "ElementsTimeEvidences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementTerms_GroupTermId",
                table: "ElementTerms",
                column: "GroupTermId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedOtherWorkTimeEvidences_CrewId",
                table: "GroupedOtherWorkTimeEvidences",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedOtherWorkTimeEvidences_LevelId",
                table: "GroupedOtherWorkTimeEvidences",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedOtherWorkTimeEvidences_ProjectId",
                table: "GroupedOtherWorkTimeEvidences",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTerms_CraneId",
                table: "GroupTerms",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTerms_LevelId",
                table: "GroupTerms",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTerms_ProjectId",
                table: "GroupTerms",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherWorksTimeEvidences_GroupedOtherWorkTimeEvidenceId",
                table: "OtherWorksTimeEvidences",
                column: "GroupedOtherWorkTimeEvidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherWorksTimeEvidences_OtherWorkOptionId",
                table: "OtherWorksTimeEvidences",
                column: "OtherWorkOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CrewSummaries_CrewSummaryId",
                table: "Worker_CrewSummaries",
                column: "CrewSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTimeEvidences_CrewSummaryId",
                table: "WorkerTimeEvidences",
                column: "CrewSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTimeEvidences_ProjectId",
                table: "WorkerTimeEvidences",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTimeEvidences_UserId",
                table: "WorkerTimeEvidences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTimeEvidences_WorkerId",
                table: "WorkerTimeEvidences",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BimModel_Cranes");

            migrationBuilder.DropTable(
                name: "BimModel_Levels");

            migrationBuilder.DropTable(
                name: "CommentaryElements");

            migrationBuilder.DropTable(
                name: "CustomParamProjects");

            migrationBuilder.DropTable(
                name: "CustomParamValues");

            migrationBuilder.DropTable(
                name: "Delay_DelayCauses");

            migrationBuilder.DropTable(
                name: "Element_ElementsTimeEvidences");

            migrationBuilder.DropTable(
                name: "ElementStatuses");

            migrationBuilder.DropTable(
                name: "ElementTerms");

            migrationBuilder.DropTable(
                name: "OtherWorksTimeEvidences");

            migrationBuilder.DropTable(
                name: "Worker_CrewSummaries");

            migrationBuilder.DropTable(
                name: "WorkerTimeEvidences");

            migrationBuilder.DropTable(
                name: "CustomParams");

            migrationBuilder.DropTable(
                name: "DelayCauses");

            migrationBuilder.DropTable(
                name: "Delays");

            migrationBuilder.DropTable(
                name: "ElementsTimeEvidences");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "GroupTerms");

            migrationBuilder.DropTable(
                name: "GroupedOtherWorkTimeEvidences");

            migrationBuilder.DropTable(
                name: "OtherWorkOptions");

            migrationBuilder.DropTable(
                name: "CrewSummaries");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "BimModels");

            migrationBuilder.DropTable(
                name: "Cranes");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
