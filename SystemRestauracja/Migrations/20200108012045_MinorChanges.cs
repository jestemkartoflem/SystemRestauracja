using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zestawy_Zamowienia_ZamowienieId",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "IdZamowienia",
                table: "Zestawy");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZamowienieId",
                table: "Zestawy",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zestawy_Zamowienia_ZamowienieId",
                table: "Zestawy",
                column: "ZamowienieId",
                principalTable: "Zamowienia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zestawy_Zamowienia_ZamowienieId",
                table: "Zestawy");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZamowienieId",
                table: "Zestawy",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "IdZamowienia",
                table: "Zestawy",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Zestawy_Zamowienia_ZamowienieId",
                table: "Zestawy",
                column: "ZamowienieId",
                principalTable: "Zamowienia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
