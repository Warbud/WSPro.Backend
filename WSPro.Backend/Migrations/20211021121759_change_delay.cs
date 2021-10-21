using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WSPro.Backend.Migrations
{
    public partial class change_delay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delay_DelayCauses_Delay_DelayId1",
                table: "Delay_DelayCauses");

            migrationBuilder.DropIndex(
                name: "IX_Delay_DelayCauses_DelayId1",
                table: "Delay_DelayCauses");

            migrationBuilder.DropColumn(
                name: "DelayId1",
                table: "Delay_DelayCauses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7184),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6637),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6372),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3779),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3461),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(2099),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1894),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.AddColumn<int>(
                name: "GroupTermId",
                table: "Elements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8712),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8376),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1266),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(7221),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6527),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6339),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6267));

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
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(4800)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(5073))
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
                name: "ElementTerms",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlannedFinish = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlannedStartBP = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlannedFinishBP = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RealStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RealFinish = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    GroupTermId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Elements_GroupTermId",
                table: "Elements",
                column: "GroupTermId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementTerms_GroupTermId",
                table: "ElementTerms",
                column: "GroupTermId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements",
                column: "GroupTermId",
                principalTable: "GroupTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements");

            migrationBuilder.DropTable(
                name: "ElementTerms");

            migrationBuilder.DropTable(
                name: "GroupTerms");

            migrationBuilder.DropIndex(
                name: "IX_Elements_GroupTermId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "GroupTermId",
                table: "Elements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(2021),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1409),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(1183),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(318),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 155, DateTimeKind.Local).AddTicks(64),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(8792),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.AddColumn<int>(
                name: "DelayId1",
                table: "Delay_DelayCauses",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(7106),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6488),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 12, 41, 15, 154, DateTimeKind.Local).AddTicks(6267),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.CreateIndex(
                name: "IX_Delay_DelayCauses_DelayId1",
                table: "Delay_DelayCauses",
                column: "DelayId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Delay_DelayCauses_Delay_DelayId1",
                table: "Delay_DelayCauses",
                column: "DelayId1",
                principalTable: "Delay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
