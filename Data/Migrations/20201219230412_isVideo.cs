using Microsoft.EntityFrameworkCore.Migrations;

namespace IS4439_CA2.Data.Migrations
{
    public partial class isVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVideo",
                table: "Projects",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVideo",
                table: "Projects");
        }
    }
}
