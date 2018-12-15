using Microsoft.EntityFrameworkCore.Migrations;

namespace LayoutService.Migrations
{
    public partial class AddPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AppSubLink",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "AppLink",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AppLink",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AppSubLink");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AppLink");

            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "AppLink",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
