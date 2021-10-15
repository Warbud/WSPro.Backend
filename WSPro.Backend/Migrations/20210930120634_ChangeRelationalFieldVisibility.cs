using Microsoft.EntityFrameworkCore.Migrations;

namespace WSPro.Backend.Migrations
{
    public partial class ChangeRelationalFieldVisibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Projects_ProjectId",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Elements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Elements",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Projects_ProjectId",
                table: "Elements",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
