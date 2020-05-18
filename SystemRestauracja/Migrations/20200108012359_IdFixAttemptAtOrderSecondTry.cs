using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class IdFixAttemptAtOrderSecondTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId1",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_ZamawiajacyId1",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "ZamawiajacyId1",
                table: "Zamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZamawiajacyId1",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ZamawiajacyId1",
                table: "Zamowienia",
                column: "ZamawiajacyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId1",
                table: "Zamowienia",
                column: "ZamawiajacyId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
