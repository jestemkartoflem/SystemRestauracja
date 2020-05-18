using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class UpdatedOrdersAndSetsUserIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_ZamawiajacyId",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "IdZamawiajacego",
                table: "Zamowienia");

            migrationBuilder.AddColumn<Guid>(
                name: "ZamawiajacyId",
                table: "Zestawy",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ZamawiajacyId1",
                table: "Zestawy",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ZamawiajacyId",
                table: "Zamowienia",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZamawiajacyId1",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zestawy_ZamawiajacyId1",
                table: "Zestawy",
                column: "ZamawiajacyId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId1",
                table: "Zestawy",
                column: "ZamawiajacyId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId1",
                table: "Zamowienia");

            migrationBuilder.DropForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId1",
                table: "Zestawy");

            migrationBuilder.DropIndex(
                name: "IX_Zestawy_ZamawiajacyId1",
                table: "Zestawy");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_ZamawiajacyId1",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "ZamawiajacyId",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "ZamawiajacyId1",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "ZamawiajacyId1",
                table: "Zamowienia");

            migrationBuilder.AlterColumn<string>(
                name: "ZamawiajacyId",
                table: "Zamowienia",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "IdZamawiajacego",
                table: "Zamowienia",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ZamawiajacyId",
                table: "Zamowienia",
                column: "ZamawiajacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId",
                table: "Zamowienia",
                column: "ZamawiajacyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
