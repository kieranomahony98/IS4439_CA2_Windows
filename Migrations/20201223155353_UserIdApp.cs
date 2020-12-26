using Microsoft.EntityFrameworkCore.Migrations;

namespace IS4439_CA2.Migrations
{
    public partial class UserIdApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserId",
                table: "ProjectComments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ProjectComments",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_ApplicationUserId",
                table: "ProjectComments",
                newName: "IX_ProjectComments_ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserID",
                table: "ProjectComments",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserID",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "ProjectComments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_ApplicationUserID",
                table: "ProjectComments",
                newName: "IX_ProjectComments_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "ProjectComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserId",
                table: "ProjectComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
