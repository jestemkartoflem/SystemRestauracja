using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class RemovedNotatkaFromDDZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notatka",
                table: "DaniaDoZestawu");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Symbole",
                newName: "ObrazUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObrazUrl",
                table: "Symbole",
                newName: "ImagePath");

            migrationBuilder.AddColumn<string>(
                name: "Notatka",
                table: "DaniaDoZestawu",
                nullable: true);
        }
    }
}
