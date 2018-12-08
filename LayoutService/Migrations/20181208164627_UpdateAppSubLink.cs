using Microsoft.EntityFrameworkCore.Migrations;

namespace LayoutService.Migrations
{
    public partial class UpdateAppSubLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubLink_AppLink_AppLinkId",
                table: "AppSubLink");

            migrationBuilder.AlterColumn<int>(
                name: "AppLinkId",
                table: "AppSubLink",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubLink_AppLink_AppLinkId",
                table: "AppSubLink",
                column: "AppLinkId",
                principalTable: "AppLink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubLink_AppLink_AppLinkId",
                table: "AppSubLink");

            migrationBuilder.AlterColumn<int>(
                name: "AppLinkId",
                table: "AppSubLink",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubLink_AppLink_AppLinkId",
                table: "AppSubLink",
                column: "AppLinkId",
                principalTable: "AppLink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
