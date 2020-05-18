using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class removedtestmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symbole_Dania_DanieId",
                table: "Symbole");

            migrationBuilder.DropIndex(
                name: "IX_Symbole_DanieId",
                table: "Symbole");

            migrationBuilder.DropColumn(
                name: "DanieId",
                table: "Symbole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DanieId",
                table: "Symbole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Symbole_DanieId",
                table: "Symbole",
                column: "DanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Symbole_Dania_DanieId",
                table: "Symbole",
                column: "DanieId",
                principalTable: "Dania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
