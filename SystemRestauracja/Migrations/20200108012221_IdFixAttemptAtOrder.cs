using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class IdFixAttemptAtOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId1",
                table: "Zestawy");

            migrationBuilder.DropIndex(
                name: "IX_Zestawy_ZamawiajacyId1",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "ZamawiajacyId1",
                table: "Zestawy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZamawiajacyId1",
                table: "Zestawy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zestawy_ZamawiajacyId1",
                table: "Zestawy",
                column: "ZamawiajacyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId1",
                table: "Zestawy",
                column: "ZamawiajacyId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
