using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class DwapiSanpsRev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SnapshotSiteCode",
                table: "MasterFacilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SnapshotVersion",
                table: "MasterFacilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SnapshotSiteCode",
                table: "Facilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SnapshotVersion",
                table: "Facilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnapshotSiteCode",
                table: "MasterFacilities");

            migrationBuilder.DropColumn(
                name: "SnapshotVersion",
                table: "MasterFacilities");

            migrationBuilder.DropColumn(
                name: "SnapshotSiteCode",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "SnapshotVersion",
                table: "Facilities");
        }
    }
}
