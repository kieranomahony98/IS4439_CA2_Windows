using Microsoft.EntityFrameworkCore.Migrations;

namespace IS4439_CA2.Migrations
{
    public partial class Dir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dir",
                table: "Projects",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dir",
                table: "Projects");
        }
    }
}
