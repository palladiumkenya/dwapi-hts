using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class AddedDateCreatedAndModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SyphilisResult",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HtsPartnerTracings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "HtsPartnerTracings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HtsClientTracing",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "HtsClientTracing",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approach",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setting",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriorityPopulationType",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "ClientPartners",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "ClientPartners",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "ClientLinkages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "SyphilisResult",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HtsPartnerTracings");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "HtsPartnerTracings");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HtsClientTracing");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "HtsClientTracing");

            migrationBuilder.DropColumn(
                name: "Approach",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "Setting",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PriorityPopulationType",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "ClientPartners");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "ClientPartners");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "ClientLinkages");
        }
    }
}
