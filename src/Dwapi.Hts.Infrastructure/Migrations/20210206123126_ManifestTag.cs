using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class ManifestTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Session",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Manifests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "Session",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Manifests");
        }
    }
}
