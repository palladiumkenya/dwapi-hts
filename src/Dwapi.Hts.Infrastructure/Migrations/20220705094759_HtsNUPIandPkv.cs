using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsNUPIandPkv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NUPI",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pkv",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NUPI",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Pkv",
                table: "Clients");
        }
    }
}
