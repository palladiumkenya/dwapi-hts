using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class DwapiSanps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SnapshotDate",
                table: "MasterFacilities",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmrId",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmrName",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmrSetup",
                table: "Manifests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Emr",
                table: "Facilities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SnapshotDate",
                table: "Facilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnapshotDate",
                table: "MasterFacilities");

            migrationBuilder.DropColumn(
                name: "EmrId",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "EmrName",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "EmrSetup",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "Emr",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "SnapshotDate",
                table: "Facilities");
        }
    }
}
