using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class SymbolImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Symbole");

            migrationBuilder.RenameColumn(
                name: "FontId",
                table: "Symbole",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Symbole",
                newName: "FontId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Symbole",
                nullable: true);
        }
    }
}
