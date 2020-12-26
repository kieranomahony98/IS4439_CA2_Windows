using Microsoft.EntityFrameworkCore.Migrations;

namespace IS4439_CA2.Migrations
{
    public partial class minor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_ProjectId",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectComments",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_ProjectId",
                table: "ProjectComments",
                newName: "IX_ProjectComments_ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_ProjectID",
                table: "ProjectComments",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_ProjectID",
                table: "ProjectComments");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "ProjectComments",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectComments_ProjectID",
                table: "ProjectComments",
                newName: "IX_ProjectComments_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_ProjectId",
                table: "ProjectComments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
