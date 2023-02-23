using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class AddedMissingVariablesandRiskScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Last_Modified",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HtsRiskCategory",
                table: "HtsClientTests",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HtsRiskScore",
                table: "HtsClientTests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "Date_Last_Modified",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "HtsRiskCategory",
                table: "HtsClientTests");

            migrationBuilder.DropColumn(
                name: "HtsRiskScore",
                table: "HtsClientTests");
        }
    }
}
