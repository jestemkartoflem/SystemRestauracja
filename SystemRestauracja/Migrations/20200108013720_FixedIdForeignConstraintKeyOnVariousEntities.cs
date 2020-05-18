using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class FixedIdForeignConstraintKeyOnVariousEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaniaDoZestawu_Dania_DanieId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropForeignKey(
                name: "FK_DaniaDoZestawu_Zestawy_ZestawId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "IdDanie",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "IdZestaw",
                table: "DaniaDoZestawu");

            migrationBuilder.AlterColumn<string>(
                name: "ZamawiajacyId",
                table: "Zestawy",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ZamawiajacyId",
                table: "Zamowienia",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ZestawId",
                table: "DaniaDoZestawu",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DanieId",
                table: "DaniaDoZestawu",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zestawy_ZamawiajacyId",
                table: "Zestawy",
                column: "ZamawiajacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ZamawiajacyId",
                table: "Zamowienia",
                column: "ZamawiajacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaDoZestawu_Dania_DanieId",
                table: "DaniaDoZestawu",
                column: "DanieId",
                principalTable: "Dania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaDoZestawu_Zestawy_ZestawId",
                table: "DaniaDoZestawu",
                column: "ZestawId",
                principalTable: "Zestawy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId",
                table: "Zamowienia",
                column: "ZamawiajacyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId",
                table: "Zestawy",
                column: "ZamawiajacyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaniaDoZestawu_Dania_DanieId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropForeignKey(
                name: "FK_DaniaDoZestawu_Zestawy_ZestawId",
                table: "DaniaDoZestawu");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_AspNetUsers_ZamawiajacyId",
                table: "Zamowienia");

            migrationBuilder.DropForeignKey(
                name: "FK_Zestawy_AspNetUsers_ZamawiajacyId",
                table: "Zestawy");

            migrationBuilder.DropIndex(
                name: "IX_Zestawy_ZamawiajacyId",
                table: "Zestawy");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_ZamawiajacyId",
                table: "Zamowienia");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZamawiajacyId",
                table: "Zestawy",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ZamawiajacyId",
                table: "Zamowienia",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ZestawId",
                table: "DaniaDoZestawu",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DanieId",
                table: "DaniaDoZestawu",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "IdDanie",
                table: "DaniaDoZestawu",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdZestaw",
                table: "DaniaDoZestawu",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaDoZestawu_Dania_DanieId",
                table: "DaniaDoZestawu",
                column: "DanieId",
                principalTable: "Dania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaDoZestawu_Zestawy_ZestawId",
                table: "DaniaDoZestawu",
                column: "ZestawId",
                principalTable: "Zestawy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
