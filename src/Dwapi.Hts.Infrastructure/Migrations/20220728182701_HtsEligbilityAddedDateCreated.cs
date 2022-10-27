using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsEligbilityAddedDateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentlyHasTB",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "EmotionalViolence",
                table: "HtsEligibilityExtract");

            migrationBuilder.RenameColumn(
                name: "PartnerHivStatus",
                table: "HtsEligibilityExtract",
                newName: "PartnerHIVStatus");

            migrationBuilder.RenameColumn(
                name: "SexualViolence",
                table: "HtsEligibilityExtract",
                newName: "Lethargy");

            migrationBuilder.RenameColumn(
                name: "PhysicalViolence",
                table: "HtsEligibilityExtract",
                newName: "ContactWithTBCase");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "HtsEligibilityExtract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "HtsEligibilityExtract");

            migrationBuilder.RenameColumn(
                name: "PartnerHIVStatus",
                table: "HtsEligibilityExtract",
                newName: "PartnerHivStatus");

            migrationBuilder.RenameColumn(
                name: "Lethargy",
                table: "HtsEligibilityExtract",
                newName: "SexualViolence");

            migrationBuilder.RenameColumn(
                name: "ContactWithTBCase",
                table: "HtsEligibilityExtract",
                newName: "PhysicalViolence");

            migrationBuilder.AddColumn<string>(
                name: "CurrentlyHasTB",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmotionalViolence",
                table: "HtsEligibilityExtract",
                nullable: true);
        }
    }
}
