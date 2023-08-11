using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class AddRiskScoreToEligibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HtsRiskScore",
                table: "HtsEligibilityExtract",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherReferredServices",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferredForServices",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferredServices",
                table: "HtsClientTests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtsRiskScore",
                table: "HtsEligibilityExtract");

            migrationBuilder.DropColumn(
                name: "OtherReferredServices",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "ReferredForServices",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "ReferredServices",
                table: "HtsClientTests");
        }
    }
}
