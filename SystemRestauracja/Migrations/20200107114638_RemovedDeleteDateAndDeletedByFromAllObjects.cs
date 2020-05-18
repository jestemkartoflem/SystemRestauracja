using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class RemovedDeleteDateAndDeletedByFromAllObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Zestawy");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Kategorie");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Kategorie");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DaniaDoZestawu");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Dania");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Dania");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Zestawy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Zestawy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Zamowienia",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Kategorie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Kategorie",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "DaniaDoZestawu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DaniaDoZestawu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Dania",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Dania",
                nullable: true);
        }
    }
}
