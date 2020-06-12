using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class LinkTestsWithFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HtsClientTests_FacilityId",
                table: "HtsClientTests",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HtsClientTests_Facilities_FacilityId",
                table: "HtsClientTests",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HtsClientTests_Facilities_FacilityId",
                table: "HtsClientTests");

            migrationBuilder.DropIndex(
                name: "IX_HtsClientTests_FacilityId",
                table: "HtsClientTests");
        }
    }
}
