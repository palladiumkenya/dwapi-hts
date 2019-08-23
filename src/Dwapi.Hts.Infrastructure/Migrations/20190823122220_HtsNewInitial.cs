using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsNewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EncounterId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCounty",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePrefferedToBeEnrolled",
                table: "ClientLinkages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FacilityReferredTo",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HandedOverTo",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HandedOverToCadre",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedCCCNumber",
                table: "ClientLinkages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedStartARTDate",
                table: "ClientLinkages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "HtsClientTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    EncounterId = table.Column<int>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: false),
                    EverTestedForHiv = table.Column<string>(nullable: true),
                    MonthsSinceLastTest = table.Column<int>(nullable: true),
                    ClientTestedAs = table.Column<string>(nullable: true),
                    EntryPoint = table.Column<string>(nullable: true),
                    TestStrategy = table.Column<string>(nullable: true),
                    TestResult1 = table.Column<string>(nullable: true),
                    TestResult2 = table.Column<string>(nullable: true),
                    FinalTestResult = table.Column<string>(nullable: true),
                    PatientGivenResult = table.Column<string>(nullable: true),
                    TbScreening = table.Column<string>(nullable: true),
                    ClientSelfTested = table.Column<string>(nullable: true),
                    CoupleDiscordant = table.Column<string>(nullable: true),
                    TestType = table.Column<string>(nullable: true),
                    Consent = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtsClientTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HtsClientTracing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    TracingType = table.Column<string>(nullable: true),
                    TracingDate = table.Column<DateTime>(nullable: false),
                    TracingOutcome = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtsClientTracing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HtsPartnerNotificationServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    EncounterId = table.Column<int>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: false),
                    EverTestedForHiv = table.Column<string>(nullable: true),
                    MonthsSinceLastTest = table.Column<int>(nullable: true),
                    ClientTestedAs = table.Column<string>(nullable: true),
                    EntryPoint = table.Column<string>(nullable: true),
                    TestStrategy = table.Column<string>(nullable: true),
                    TestResult1 = table.Column<string>(nullable: true),
                    TestResult2 = table.Column<string>(nullable: true),
                    FinalTestResult = table.Column<string>(nullable: true),
                    PatientGivenResult = table.Column<string>(nullable: true),
                    TbScreening = table.Column<string>(nullable: true),
                    ClientSelfTested = table.Column<string>(nullable: true),
                    CoupleDiscordant = table.Column<string>(nullable: true),
                    TestType = table.Column<string>(nullable: true),
                    Consent = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtsPartnerNotificationServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HtsPartnerTracings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    TraceType = table.Column<string>(nullable: true),
                    TraceDate = table.Column<DateTime>(nullable: false),
                    TraceOutcome = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtsPartnerTracings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HtsTestKits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    EncounterId = table.Column<int>(nullable: false),
                    TestKitName1 = table.Column<string>(nullable: true),
                    TestKitLotNumber1 = table.Column<string>(nullable: true),
                    TestKitExpiry1 = table.Column<string>(nullable: true),
                    TestResult1 = table.Column<string>(nullable: true),
                    TestKitName2 = table.Column<string>(nullable: true),
                    TestKitLotNumber2 = table.Column<string>(nullable: true),
                    TestKitExpiry2 = table.Column<string>(nullable: true),
                    TestResult2 = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtsTestKits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtsClientTests");

            migrationBuilder.DropTable(
                name: "HtsClientTracing");

            migrationBuilder.DropTable(
                name: "HtsPartnerNotificationServices");

            migrationBuilder.DropTable(
                name: "HtsPartnerTracings");

            migrationBuilder.DropTable(
                name: "HtsTestKits");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SubCounty",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DatePrefferedToBeEnrolled",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "FacilityReferredTo",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "HandedOverTo",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "HandedOverToCadre",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "ReportedCCCNumber",
                table: "ClientLinkages");

            migrationBuilder.DropColumn(
                name: "ReportedStartARTDate",
                table: "ClientLinkages");

            migrationBuilder.AlterColumn<int>(
                name: "EncounterId",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
