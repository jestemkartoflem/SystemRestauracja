using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemRestauracja.Migrations
{
    public partial class NotatkaDoZestawu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotatkaDoZestawu",
                table: "Zestawy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotatkaDoZestawu",
                table: "Zestawy");
        }
    }
}
