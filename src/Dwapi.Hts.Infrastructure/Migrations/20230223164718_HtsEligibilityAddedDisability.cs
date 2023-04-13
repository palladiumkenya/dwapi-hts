using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsEligibilityAddedDisability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Disability",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityType",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HIVRiskCategory",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTSEntryPoint",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTSStrategy",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonNotReffered",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonRefferredForTesting",
                table: "HtsEligibilityExtract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disability",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "DisabilityType",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "HIVRiskCategory",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "HTSEntryPoint",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "HTSStrategy",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ReasonNotReffered",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "ReasonRefferredForTesting",
                table: "HtsEligibilityExtract");
        }
    }
}
