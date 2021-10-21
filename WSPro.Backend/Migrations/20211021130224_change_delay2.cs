using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSPro.Backend.Migrations
{
    public partial class change_delay2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5218),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5050),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4347),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(3042),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(5073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(2791),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1873),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1613),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(154),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.AlterColumn<int>(
                name: "GroupTermId",
                table: "Elements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9964),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(7160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9617),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9366),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5924),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5650),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5344),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5126),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements",
                column: "GroupTermId",
                principalTable: "GroupTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(7184),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6637),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(6372),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(5073),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(4800),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3779),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(3461),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(2099),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.AlterColumn<int>(
                name: "GroupTermId",
                table: "Elements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1894),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8712),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(8376),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 976, DateTimeKind.Local).AddTicks(1266),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(7221),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6527),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 14, 17, 58, 975, DateTimeKind.Local).AddTicks(6339),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5126));

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_GroupTerms_GroupTermId",
                table: "Elements",
                column: "GroupTermId",
                principalTable: "GroupTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
