using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class RestoredDeleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Zestawy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Kategorie",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "DaniaDoZestawu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Dania",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Kategorie");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Dania");
        }
    }
}
