using Microsoft.EntityFrameworkCore.Migrations;

namespace WSPro.Backend.Infrastructure.Migrations
{
    public partial class changeElementStatusPreviousStatustooptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatus_Elements_ElementId",
                table: "ElementStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatus_ElementStatus_PreviousStatusId",
                table: "ElementStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatus_Projects_ProjectId",
                table: "ElementStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatus_Users_UserId",
                table: "ElementStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElementStatus",
                table: "ElementStatus");

            migrationBuilder.RenameTable(
                name: "ElementStatus",
                newName: "ElementStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatus_UserId",
                table: "ElementStatuses",
                newName: "IX_ElementStatuses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatus_ProjectId",
                table: "ElementStatuses",
                newName: "IX_ElementStatuses_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatus_PreviousStatusId",
                table: "ElementStatuses",
                newName: "IX_ElementStatuses_PreviousStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatus_ElementId",
                table: "ElementStatuses",
                newName: "IX_ElementStatuses_ElementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElementStatuses",
                table: "ElementStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatuses_Elements_ElementId",
                table: "ElementStatuses",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatuses_ElementStatuses_PreviousStatusId",
                table: "ElementStatuses",
                column: "PreviousStatusId",
                principalTable: "ElementStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatuses_Projects_ProjectId",
                table: "ElementStatuses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatuses_Users_UserId",
                table: "ElementStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatuses_Elements_ElementId",
                table: "ElementStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatuses_ElementStatuses_PreviousStatusId",
                table: "ElementStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatuses_Projects_ProjectId",
                table: "ElementStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementStatuses_Users_UserId",
                table: "ElementStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElementStatuses",
                table: "ElementStatuses");

            migrationBuilder.RenameTable(
                name: "ElementStatuses",
                newName: "ElementStatus");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatuses_UserId",
                table: "ElementStatus",
                newName: "IX_ElementStatus_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatuses_ProjectId",
                table: "ElementStatus",
                newName: "IX_ElementStatus_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatuses_PreviousStatusId",
                table: "ElementStatus",
                newName: "IX_ElementStatus_PreviousStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementStatuses_ElementId",
                table: "ElementStatus",
                newName: "IX_ElementStatus_ElementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElementStatus",
                table: "ElementStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatus_Elements_ElementId",
                table: "ElementStatus",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatus_ElementStatus_PreviousStatusId",
                table: "ElementStatus",
                column: "PreviousStatusId",
                principalTable: "ElementStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatus_Projects_ProjectId",
                table: "ElementStatus",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementStatus_Users_UserId",
                table: "ElementStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
