using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EncounterId",
                table: "HtsTestKits",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TraceDate",
                table: "HtsPartnerTracings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "HtsPartnerTracings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TracingDate",
                table: "HtsClientTracing",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TestDate",
                table: "HtsClientTests",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ClientPartners",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EncounterId",
                table: "HtsTestKits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TraceDate",
                table: "HtsPartnerTracings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "HtsPartnerTracings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TracingDate",
                table: "HtsClientTracing",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TestDate",
                table: "HtsClientTests",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ClientPartners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
