using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class RemovedLongDescriptionFromDanie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisDaniaDlugi",
                table: "Dania");

            migrationBuilder.RenameColumn(
                name: "OpisDaniaKrotki",
                table: "Dania",
                newName: "OpisDania");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpisDania",
                table: "Dania",
                newName: "OpisDaniaKrotki");

            migrationBuilder.AddColumn<string>(
                name: "OpisDaniaDlugi",
                table: "Dania",
                nullable: true);
        }
    }
}
