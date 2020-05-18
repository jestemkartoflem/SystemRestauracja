using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class ChangedWhitespacelessToNormalizedNameInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Whitespaceless",
                table: "Kategorie",
                newName: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "Kategorie",
                newName: "Whitespaceless");
        }
    }
}
