using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class UniqueNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Symbole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Kategorie",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Dania",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Symbole_Nazwa",
                table: "Symbole",
                column: "Nazwa",
                unique: true,
                filter: "[Nazwa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorie_Nazwa",
                table: "Kategorie",
                column: "Nazwa",
                unique: true,
                filter: "[Nazwa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dania_Nazwa",
                table: "Dania",
                column: "Nazwa",
                unique: true,
                filter: "[Nazwa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Symbole_Nazwa",
                table: "Symbole");

            migrationBuilder.DropIndex(
                name: "IX_Kategorie_Nazwa",
                table: "Kategorie");

            migrationBuilder.DropIndex(
                name: "IX_Dania_Nazwa",
                table: "Dania");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Symbole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Kategorie",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Dania",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
