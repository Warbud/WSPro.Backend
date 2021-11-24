using Microsoft.EntityFrameworkCore.Migrations;

namespace WSPro.Backend.Migrations
{
    public partial class addSupportedModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupportedModules",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportedModules",
                table: "Projects");
        }
    }
}
