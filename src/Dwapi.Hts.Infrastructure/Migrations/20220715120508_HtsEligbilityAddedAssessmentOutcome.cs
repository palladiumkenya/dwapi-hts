using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsEligbilityAddedAssessmentOutcome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssessmentOutcome",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForcedSex",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceivedServices",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeGBV",
                table: "HtsEligibilityExtract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssessmentOutcome",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ForcedSex",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ReceivedServices",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "TypeGBV",
                table: "HtsEligibilityExtract");
        }
    }
}
