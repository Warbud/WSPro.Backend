using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSPro.Backend.Migrations
{
    public partial class change_delay3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(4177),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3955),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3454),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3255),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1808),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedStartBP",
                table: "GroupTerms",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedFinishBP",
                table: "GroupTerms",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(577),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(355),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8826),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5673),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5370),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8207),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(7986),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4038),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3667),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5126));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5218),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(5050),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Levels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(4347),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(3042),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedStartBP",
                table: "GroupTerms",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedFinishBP",
                table: "GroupTerms",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupTerms",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(2791),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1873),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ElementStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(1613),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 301, DateTimeKind.Local).AddTicks(154),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Elements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9964),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(7160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9617),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay_DelayCauses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(9366),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5924),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Delay",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5650),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5344),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cranes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 15, 2, 24, 300, DateTimeKind.Local).AddTicks(5126),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3485));
        }
    }
}
