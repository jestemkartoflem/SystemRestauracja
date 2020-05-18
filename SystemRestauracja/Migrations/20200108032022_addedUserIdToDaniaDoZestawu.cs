using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class addedUserIdToDaniaDoZestawu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DaniaDoZestawu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaniaDoZestawu_UserId",
                table: "DaniaDoZestawu",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaDoZestawu_AspNetUsers_UserId",
                table: "DaniaDoZestawu",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaniaDoZestawu_AspNetUsers_UserId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropIndex(
                name: "IX_DaniaDoZestawu_UserId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DaniaDoZestawu");
        }
    }
}
