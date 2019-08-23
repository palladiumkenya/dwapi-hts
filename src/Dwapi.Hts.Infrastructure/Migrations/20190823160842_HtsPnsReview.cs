using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsPnsReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSelfTested",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.RenameColumn(
                name: "TestType",
                table: "HtsPartnerNotificationServices",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "TestStrategy",
                table: "HtsPartnerNotificationServices",
                newName: "ScreenedForIpv");

            migrationBuilder.RenameColumn(
                name: "TestResult2",
                table: "HtsPartnerNotificationServices",
                newName: "RelationsipToIndexClient");

            migrationBuilder.RenameColumn(
                name: "TestResult1",
                table: "HtsPartnerNotificationServices",
                newName: "PnsConsent");

            migrationBuilder.RenameColumn(
                name: "TbScreening",
                table: "HtsPartnerNotificationServices",
                newName: "PnsApproach");

            migrationBuilder.RenameColumn(
                name: "PatientGivenResult",
                table: "HtsPartnerNotificationServices",
                newName: "MaritalStatus");

            migrationBuilder.RenameColumn(
                name: "MonthsSinceLastTest",
                table: "HtsPartnerNotificationServices",
                newName: "PartnerPersonID");

            migrationBuilder.RenameColumn(
                name: "FinalTestResult",
                table: "HtsPartnerNotificationServices",
                newName: "LinkedToCare");

            migrationBuilder.RenameColumn(
                name: "EverTestedForHiv",
                table: "HtsPartnerNotificationServices",
                newName: "KnowledgeOfHivStatus");

            migrationBuilder.RenameColumn(
                name: "EntryPoint",
                table: "HtsPartnerNotificationServices",
                newName: "IpvScreeningOutcome");

            migrationBuilder.RenameColumn(
                name: "EncounterId",
                table: "HtsPartnerNotificationServices",
                newName: "PartnerPatientPk");

            migrationBuilder.RenameColumn(
                name: "CoupleDiscordant",
                table: "HtsPartnerNotificationServices",
                newName: "FacilityLinkedTo");

            migrationBuilder.RenameColumn(
                name: "Consent",
                table: "HtsPartnerNotificationServices",
                newName: "CurrentlyLivingWithIndexClient");

            migrationBuilder.RenameColumn(
                name: "ClientTestedAs",
                table: "HtsPartnerNotificationServices",
                newName: "CccNumber");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateElicited",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LinkDateLinkedToCare",
                table: "HtsPartnerNotificationServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "DateElicited",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropColumn(
                name: "LinkDateLinkedToCare",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "HtsPartnerNotificationServices",
                newName: "TestType");

            migrationBuilder.RenameColumn(
                name: "ScreenedForIpv",
                table: "HtsPartnerNotificationServices",
                newName: "TestStrategy");

            migrationBuilder.RenameColumn(
                name: "RelationsipToIndexClient",
                table: "HtsPartnerNotificationServices",
                newName: "TestResult2");

            migrationBuilder.RenameColumn(
                name: "PnsConsent",
                table: "HtsPartnerNotificationServices",
                newName: "TestResult1");

            migrationBuilder.RenameColumn(
                name: "PnsApproach",
                table: "HtsPartnerNotificationServices",
                newName: "TbScreening");

            migrationBuilder.RenameColumn(
                name: "PartnerPersonID",
                table: "HtsPartnerNotificationServices",
                newName: "MonthsSinceLastTest");

            migrationBuilder.RenameColumn(
                name: "PartnerPatientPk",
                table: "HtsPartnerNotificationServices",
                newName: "EncounterId");

            migrationBuilder.RenameColumn(
                name: "MaritalStatus",
                table: "HtsPartnerNotificationServices",
                newName: "PatientGivenResult");

            migrationBuilder.RenameColumn(
                name: "LinkedToCare",
                table: "HtsPartnerNotificationServices",
                newName: "FinalTestResult");

            migrationBuilder.RenameColumn(
                name: "KnowledgeOfHivStatus",
                table: "HtsPartnerNotificationServices",
                newName: "EverTestedForHiv");

            migrationBuilder.RenameColumn(
                name: "IpvScreeningOutcome",
                table: "HtsPartnerNotificationServices",
                newName: "EntryPoint");

            migrationBuilder.RenameColumn(
                name: "FacilityLinkedTo",
                table: "HtsPartnerNotificationServices",
                newName: "CoupleDiscordant");

            migrationBuilder.RenameColumn(
                name: "CurrentlyLivingWithIndexClient",
                table: "HtsPartnerNotificationServices",
                newName: "Consent");

            migrationBuilder.RenameColumn(
                name: "CccNumber",
                table: "HtsPartnerNotificationServices",
                newName: "ClientTestedAs");

            migrationBuilder.AddColumn<string>(
                name: "ClientSelfTested",
                table: "HtsPartnerNotificationServices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TestDate",
                table: "HtsPartnerNotificationServices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
