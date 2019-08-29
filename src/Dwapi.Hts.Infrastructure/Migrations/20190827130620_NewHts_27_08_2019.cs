using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class NewHts_27_08_2019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HtsTestKits_FacilityId",
                table: "HtsTestKits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HtsPartnerTracings_FacilityId",
                table: "HtsPartnerTracings",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HtsPartnerNotificationServices_FacilityId",
                table: "HtsPartnerNotificationServices",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HtsClientTracing_FacilityId",
                table: "HtsClientTracing",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HtsClientTracing_Facilities_FacilityId",
                table: "HtsClientTracing",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HtsPartnerNotificationServices_Facilities_FacilityId",
                table: "HtsPartnerNotificationServices",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HtsPartnerTracings_Facilities_FacilityId",
                table: "HtsPartnerTracings",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HtsTestKits_Facilities_FacilityId",
                table: "HtsTestKits",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HtsClientTracing_Facilities_FacilityId",
                table: "HtsClientTracing");

            migrationBuilder.DropForeignKey(
                name: "FK_HtsPartnerNotificationServices_Facilities_FacilityId",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HtsPartnerTracings_Facilities_FacilityId",
                table: "HtsPartnerTracings");

            migrationBuilder.DropForeignKey(
                name: "FK_HtsTestKits_Facilities_FacilityId",
                table: "HtsTestKits");

            migrationBuilder.DropIndex(
                name: "IX_HtsTestKits_FacilityId",
                table: "HtsTestKits");

            migrationBuilder.DropIndex(
                name: "IX_HtsPartnerTracings_FacilityId",
                table: "HtsPartnerTracings");

            migrationBuilder.DropIndex(
                name: "IX_HtsPartnerNotificationServices_FacilityId",
                table: "HtsPartnerNotificationServices");

            migrationBuilder.DropIndex(
                name: "IX_HtsClientTracing_FacilityId",
                table: "HtsClientTracing");
        }
    }
}
