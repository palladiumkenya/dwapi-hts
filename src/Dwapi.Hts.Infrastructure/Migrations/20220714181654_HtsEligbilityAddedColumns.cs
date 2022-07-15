using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsEligbilityAddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTested",
                table: "HtsEligibilityExtract",
                newName: "DateTestedSelf");

            migrationBuilder.AddColumn<string>(
                name: "Cough",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTestedProvider",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmotionalViolence",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fever",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersStatus",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NightSweats",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefId",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferredForTesting",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultOfHIVSelf",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenedTB",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TBStatus",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightLoss",
                table: "HtsEligibilityExtract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cough",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "DateTestedProvider",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "EmotionalViolence",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "Fever",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "MothersStatus",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "NightSweats",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ReferredForTesting",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ResultOfHIVSelf",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ScreenedTB",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "TBStatus",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "WeightLoss",
                table: "HtsEligibilityExtract");

            migrationBuilder.RenameColumn(
                name: "DateTestedSelf",
                table: "HtsEligibilityExtract",
                newName: "DateTested");
        }
    }
}
