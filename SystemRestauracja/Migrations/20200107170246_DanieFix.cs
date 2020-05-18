using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class DanieFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dania_Kategorie_kategoriaId",
                table: "Dania");

            migrationBuilder.DropIndex(
                name: "IX_Dania_kategoriaId",
                table: "Dania");

            migrationBuilder.DropColumn(
                name: "kategoriaId",
                table: "Dania");

            migrationBuilder.CreateIndex(
                name: "IX_Dania_CategoryId",
                table: "Dania",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dania_Kategorie_CategoryId",
                table: "Dania",
                column: "CategoryId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dania_Kategorie_CategoryId",
                table: "Dania");

            migrationBuilder.DropIndex(
                name: "IX_Dania_CategoryId",
                table: "Dania");

            migrationBuilder.AddColumn<Guid>(
                name: "kategoriaId",
                table: "Dania",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dania_kategoriaId",
                table: "Dania",
                column: "kategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dania_Kategorie_kategoriaId",
                table: "Dania",
                column: "kategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
