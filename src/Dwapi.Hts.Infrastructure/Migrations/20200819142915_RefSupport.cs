using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class RefSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Subscribers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "MasterFacilities",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Manifests",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsPartnerTracings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsClientTracing",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Facilities",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Dockets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "ClientPartners",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "Cargoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "MasterFacilities");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Manifests");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsPartnerTracings");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsClientTracing");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Dockets");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "ClientPartners");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Cargoes");
        }
    }
}
