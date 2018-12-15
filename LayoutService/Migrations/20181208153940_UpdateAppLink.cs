using Microsoft.EntityFrameworkCore.Migrations;

namespace LayoutService.Migrations
{
    public partial class UpdateAppLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "AppLink",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "AppLink",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
