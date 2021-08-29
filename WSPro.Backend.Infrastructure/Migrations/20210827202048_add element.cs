using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WSPro.Backend.Infrastructure.Migrations
{
    public partial class addelement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Area = table.Column<decimal>(type: "numeric", nullable: true),
                    Volume = table.Column<decimal>(type: "numeric", nullable: true),
                    RunningMetre = table.Column<decimal>(type: "numeric", nullable: true),
                    RevitID = table.Column<int>(type: "integer", nullable: false),
                    Vertical = table.Column<string>(type: "text", nullable: true),
                    RealisationMode = table.Column<string>(type: "text", nullable: true),
                    RotationDay = table.Column<int>(type: "integer", nullable: true),
                    LevelID = table.Column<int>(type: "integer", nullable: true),
                    CraneID = table.Column<int>(type: "integer", nullable: true),
                    ProjectID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Cranes_CraneID",
                        column: x => x.CraneID,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: true),
                    PreviousStatusId = table.Column<int>(type: "integer", nullable: true),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementStatus_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementStatus_ElementStatus_PreviousStatusId",
                        column: x => x.PreviousStatusId,
                        principalTable: "ElementStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementStatus_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementStatus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_CraneID",
                table: "Elements",
                column: "CraneID");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LevelID",
                table: "Elements",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ProjectID",
                table: "Elements",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatus_ElementId",
                table: "ElementStatus",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatus_PreviousStatusId",
                table: "ElementStatus",
                column: "PreviousStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatus_ProjectId",
                table: "ElementStatus",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementStatus_UserId",
                table: "ElementStatus",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementStatus");

            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
