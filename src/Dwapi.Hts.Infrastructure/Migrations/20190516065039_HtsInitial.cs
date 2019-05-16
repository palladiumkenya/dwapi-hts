using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    public partial class HtsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dockets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Instance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    County = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AuthCode = table.Column<string>(nullable: true),
                    DocketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_Dockets_DocketId",
                        column: x => x.DocketId,
                        principalTable: "Dockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    MasterFacilityId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_MasterFacilities_MasterFacilityId",
                        column: x => x.MasterFacilityId,
                        principalTable: "MasterFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientLinkages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    PhoneTracingDate = table.Column<DateTime>(nullable: true),
                    PhysicalTracingDate = table.Column<DateTime>(nullable: true),
                    TracingOutcome = table.Column<string>(nullable: true),
                    CccNumber = table.Column<string>(nullable: true),
                    EnrolledFacilityName = table.Column<string>(nullable: true),
                    ReferralDate = table.Column<DateTime>(nullable: false),
                    DateEnrolled = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLinkages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientLinkages_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPartners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    PatientPk = table.Column<int>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    PartnerPatientPk = table.Column<int>(nullable: true),
                    PartnerPersonId = table.Column<int>(nullable: true),
                    RelationshipToIndexClient = table.Column<string>(nullable: true),
                    ScreenedForIpv = table.Column<string>(nullable: true),
                    IpvScreeningOutcome = table.Column<string>(nullable: true),
                    CurrentlyLivingWithIndexClient = table.Column<string>(nullable: true),
                    KnowledgeOfHivStatus = table.Column<string>(nullable: true),
                    PnsApproach = table.Column<string>(nullable: true),
                    Trace1Outcome = table.Column<string>(nullable: true),
                    Trace1Type = table.Column<string>(nullable: true),
                    Trace1Date = table.Column<DateTime>(nullable: true),
                    Trace2Outcome = table.Column<string>(nullable: true),
                    Trace2Type = table.Column<string>(nullable: true),
                    Trace2Date = table.Column<DateTime>(nullable: true),
                    Trace3Outcome = table.Column<string>(nullable: true),
                    Trace3Type = table.Column<string>(nullable: true),
                    Trace3Date = table.Column<DateTime>(nullable: true),
                    PnsConsent = table.Column<string>(nullable: true),
                    Linked = table.Column<string>(nullable: true),
                    LinkDateLinkedToCare = table.Column<DateTime>(nullable: true),
                    CccNumber = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPartners_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HtsNumber = table.Column<string>(nullable: true),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    PatientPk = table.Column<int>(nullable: false),
                    SiteCode = table.Column<int>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: false),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false),
                    EncounterId = table.Column<int>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    KeyPop = table.Column<string>(nullable: true),
                    TestedBefore = table.Column<string>(nullable: true),
                    MonthsLastTested = table.Column<int>(nullable: true),
                    ClientTestedAs = table.Column<string>(nullable: true),
                    StrategyHTS = table.Column<string>(nullable: true),
                    TestKitName1 = table.Column<string>(nullable: true),
                    TestKitLotNumber1 = table.Column<string>(nullable: true),
                    TestKitExpiryDate1 = table.Column<DateTime>(nullable: true),
                    TestResultsHTS1 = table.Column<string>(nullable: true),
                    TestKitName2 = table.Column<string>(nullable: true),
                    TestKitLotNumber2 = table.Column<string>(nullable: true),
                    TestKitExpiryDate2 = table.Column<string>(nullable: true),
                    TestResultsHTS2 = table.Column<string>(nullable: true),
                    FinalResultHTS = table.Column<string>(nullable: true),
                    FinalResultsGiven = table.Column<string>(nullable: true),
                    TBScreeningHTS = table.Column<string>(nullable: true),
                    ClientSelfTested = table.Column<string>(nullable: true),
                    CoupleDiscordant = table.Column<string>(nullable: true),
                    TestType = table.Column<string>(nullable: true),
                    KeyPopulationType = table.Column<string>(nullable: true),
                    PopulationType = table.Column<string>(nullable: true),
                    PatientDisabled = table.Column<string>(nullable: true),
                    DisabilityType = table.Column<string>(nullable: true),
                    PatientConsented = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sent = table.Column<int>(nullable: false),
                    Recieved = table.Column<int>(nullable: false),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    DateArrived = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manifests_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Items = table.Column<string>(nullable: true),
                    ManifestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargoes_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_ManifestId",
                table: "Cargoes",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLinkages_FacilityId",
                table: "ClientLinkages",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPartners_FacilityId",
                table: "ClientPartners",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FacilityId",
                table: "Clients",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_MasterFacilityId",
                table: "Facilities",
                column: "MasterFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_FacilityId",
                table: "Manifests",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocketId",
                table: "Subscribers",
                column: "DocketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargoes");

            migrationBuilder.DropTable(
                name: "ClientLinkages");

            migrationBuilder.DropTable(
                name: "ClientPartners");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "Dockets");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "MasterFacilities");
        }
    }
}
