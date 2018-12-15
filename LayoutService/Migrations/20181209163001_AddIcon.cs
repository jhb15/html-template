using Microsoft.EntityFrameworkCore.Migrations;

namespace LayoutService.Migrations
{
    public partial class AddIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "AppSubLink",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "AppLink",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconName",
                table: "AppSubLink");

            migrationBuilder.DropColumn(
                name: "IconName",
                table: "AppLink");
        }
    }
}
