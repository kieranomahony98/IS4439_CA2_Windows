using Microsoft.EntityFrameworkCore.Migrations;

namespace IS4439_CA2.Migrations
{
    public partial class USERCommentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_AspNetUsers_applicationUserId",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "ProjectComments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_applicationUserId",
                table: "ProjectComments",
                newName: "IX_ProjectComments_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ProjectComments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserId",
                table: "ProjectComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_AspNetUsers_ApplicationUserId",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ProjectComments",
                newName: "applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_ApplicationUserId",
                table: "ProjectComments",
                newName: "IX_ProjectComments_applicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "ProjectComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_AspNetUsers_applicationUserId",
                table: "ProjectComments",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
