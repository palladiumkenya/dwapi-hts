using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class RecordUUIDandVoidedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsTestKits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsPartnerTracings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsPartnerTracings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HtsRiskScore",
                table: "HtsEligibilityExtract",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsClientTracing",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsClientTracing",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HtsRiskScore",
                table: "HtsClientTests",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "ClientPartners",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "ClientPartners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "ClientLinkages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsPartnerTracings");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsPartnerTracings");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsClientTracing");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsClientTracing");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "ClientPartners");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "ClientPartners");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "ClientLinkages");

            migrationBuilder.AlterColumn<decimal>(
                name: "HtsRiskScore",
                table: "HtsEligibilityExtract",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "HtsRiskScore",
                table: "HtsClientTests",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
