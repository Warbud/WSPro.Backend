using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WSPro.Backend.Infrastructure.Migrations
{
    public partial class addworkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    WorkerType = table.Column<int>(type: "integer", nullable: false),
                    CrewType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrewSummary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrewId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewSummary_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewSummary_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewSummary_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerTypeEnum = table.Column<int>(type: "integer", nullable: false),
                    IsHouseWorker = table.Column<bool>(type: "boolean", nullable: false),
                    AddedById = table.Column<int>(type: "integer", nullable: true),
                    CrewId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    WarbudID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worker_Users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewSummaryWorker",
                columns: table => new
                {
                    CrewSummariesId = table.Column<int>(type: "integer", nullable: false),
                    WorkersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewSummaryWorker", x => new { x.CrewSummariesId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_CrewSummaryWorker_CrewSummary_CrewSummariesId",
                        column: x => x.CrewSummariesId,
                        principalTable: "CrewSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewSummaryWorker_Worker_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crew_ProjectId",
                table: "Crew",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_UserId",
                table: "Crew",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummary_CrewId",
                table: "CrewSummary",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummary_ProjectId",
                table: "CrewSummary",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummary_UserId",
                table: "CrewSummary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSummaryWorker_WorkersId",
                table: "CrewSummaryWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_AddedById",
                table: "Worker",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CrewId",
                table: "Worker",
                column: "CrewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewSummaryWorker");

            migrationBuilder.DropTable(
                name: "CrewSummary");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Crew");
        }
    }
}
