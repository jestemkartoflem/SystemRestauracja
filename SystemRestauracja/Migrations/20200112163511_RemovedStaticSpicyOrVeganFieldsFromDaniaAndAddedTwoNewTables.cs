using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class RemovedStaticSpicyOrVeganFieldsFromDaniaAndAddedTwoNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyOstre",
                table: "Dania");

            migrationBuilder.DropColumn(
                name: "CzyWeganskie",
                table: "Dania");

            migrationBuilder.CreateTable(
                name: "Symbole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Nazwa = table.Column<string>(nullable: true),
                    FontId = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymboleDoDania",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    DanieId = table.Column<Guid>(nullable: false),
                    SymbolId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymboleDoDania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SymboleDoDania_Dania_DanieId",
                        column: x => x.DanieId,
                        principalTable: "Dania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SymboleDoDania_Symbole_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SymboleDoDania_DanieId",
                table: "SymboleDoDania",
                column: "DanieId");

            migrationBuilder.CreateIndex(
                name: "IX_SymboleDoDania_SymbolId",
                table: "SymboleDoDania",
                column: "SymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SymboleDoDania");

            migrationBuilder.DropTable(
                name: "Symbole");

            migrationBuilder.AddColumn<bool>(
                name: "CzyOstre",
                table: "Dania",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CzyWeganskie",
                table: "Dania",
                nullable: false,
                defaultValue: false);
        }
    }
}
