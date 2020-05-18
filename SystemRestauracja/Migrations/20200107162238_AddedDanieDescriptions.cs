using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class AddedDanieDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpisDaniaDlugi",
                table: "Dania",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpisDaniaKrotki",
                table: "Dania",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisDaniaDlugi",
                table: "Dania");

            migrationBuilder.DropColumn(
                name: "OpisDaniaKrotki",
                table: "Dania");
        }
    }
}
