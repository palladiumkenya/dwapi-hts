﻿// <auto-generated />
using System;
using Dwapi.Hts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dwapi.Hts.Infrastructure.Migrations
{
    [DbContext(typeof(HtsContext))]
    [Migration("20190516065039_HtsInitial")]
    partial class HtsInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Items");

                    b.Property<Guid>("ManifestId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ManifestId");

                    b.ToTable("Cargoes");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Docket", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instance");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Dockets");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("MasterFacilityId");

                    b.Property<string>("Name")
                        .HasMaxLength(120);

                    b.Property<int>("SiteCode");

                    b.HasKey("Id");

                    b.HasIndex("MasterFacilityId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientSelfTested");

                    b.Property<string>("ClientTestedAs");

                    b.Property<string>("CoupleDiscordant");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateExtracted");

                    b.Property<string>("DisabilityType");

                    b.Property<DateTime?>("Dob");

                    b.Property<string>("Emr");

                    b.Property<int>("EncounterId");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("FacilityName");

                    b.Property<string>("FinalResultHTS");

                    b.Property<string>("FinalResultsGiven");

                    b.Property<string>("Gender");

                    b.Property<string>("HtsNumber");

                    b.Property<string>("KeyPop");

                    b.Property<string>("KeyPopulationType");

                    b.Property<string>("MaritalStatus");

                    b.Property<int?>("MonthsLastTested");

                    b.Property<string>("PatientConsented");

                    b.Property<string>("PatientDisabled");

                    b.Property<int>("PatientPk");

                    b.Property<string>("PopulationType");

                    b.Property<bool?>("Processed");

                    b.Property<string>("Project");

                    b.Property<string>("QueueId");

                    b.Property<string>("Serial");

                    b.Property<int>("SiteCode");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("StatusDate");

                    b.Property<string>("StrategyHTS");

                    b.Property<string>("TBScreeningHTS");

                    b.Property<DateTime?>("TestKitExpiryDate1");

                    b.Property<string>("TestKitExpiryDate2");

                    b.Property<string>("TestKitLotNumber1");

                    b.Property<string>("TestKitLotNumber2");

                    b.Property<string>("TestKitName1");

                    b.Property<string>("TestKitName2");

                    b.Property<string>("TestResultsHTS1");

                    b.Property<string>("TestResultsHTS2");

                    b.Property<string>("TestType");

                    b.Property<string>("TestedBefore");

                    b.Property<DateTime?>("VisitDate");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClientLinkage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CccNumber");

                    b.Property<DateTime>("DateEnrolled");

                    b.Property<DateTime?>("DateExtracted");

                    b.Property<string>("Emr");

                    b.Property<string>("EnrolledFacilityName");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("FacilityName");

                    b.Property<string>("HtsNumber");

                    b.Property<int>("PatientPk");

                    b.Property<DateTime?>("PhoneTracingDate");

                    b.Property<DateTime?>("PhysicalTracingDate");

                    b.Property<bool?>("Processed");

                    b.Property<string>("Project");

                    b.Property<string>("QueueId");

                    b.Property<DateTime>("ReferralDate");

                    b.Property<int>("SiteCode");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("StatusDate");

                    b.Property<string>("TracingOutcome");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("ClientLinkages");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClientPartner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CccNumber");

                    b.Property<string>("CurrentlyLivingWithIndexClient");

                    b.Property<DateTime?>("DateExtracted");

                    b.Property<string>("Emr");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("FacilityName");

                    b.Property<string>("HtsNumber");

                    b.Property<string>("IpvScreeningOutcome");

                    b.Property<string>("KnowledgeOfHivStatus");

                    b.Property<DateTime?>("LinkDateLinkedToCare");

                    b.Property<string>("Linked");

                    b.Property<int?>("PartnerPatientPk");

                    b.Property<int?>("PartnerPersonId");

                    b.Property<int>("PatientPk");

                    b.Property<string>("PnsApproach");

                    b.Property<string>("PnsConsent");

                    b.Property<bool?>("Processed");

                    b.Property<string>("Project");

                    b.Property<string>("QueueId");

                    b.Property<string>("RelationshipToIndexClient");

                    b.Property<string>("ScreenedForIpv");

                    b.Property<string>("Sex");

                    b.Property<int>("SiteCode");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("StatusDate");

                    b.Property<DateTime?>("Trace1Date");

                    b.Property<string>("Trace1Outcome");

                    b.Property<string>("Trace1Type");

                    b.Property<DateTime?>("Trace2Date");

                    b.Property<string>("Trace2Outcome");

                    b.Property<string>("Trace2Type");

                    b.Property<DateTime?>("Trace3Date");

                    b.Property<string>("Trace3Outcome");

                    b.Property<string>("Trace3Type");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("ClientPartners");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Manifest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateArrived");

                    b.Property<DateTime>("DateLogged");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("Name");

                    b.Property<int>("Recieved");

                    b.Property<int>("Sent");

                    b.Property<int>("SiteCode");

                    b.Property<int>("Status");

                    b.Property<DateTime>("StatusDate");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Manifests");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.MasterFacility", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("County")
                        .HasMaxLength(120);

                    b.Property<string>("Name")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("MasterFacilities");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Subscriber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthCode");

                    b.Property<string>("DocketId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DocketId");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Cargo", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Manifest")
                        .WithMany("Cargoes")
                        .HasForeignKey("ManifestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Facility", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.MasterFacility")
                        .WithMany("Mentions")
                        .HasForeignKey("MasterFacilityId");
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClient", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Facility")
                        .WithMany("Clients")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClientLinkage", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Facility")
                        .WithMany("Linkages")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.HtsClientPartner", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Facility")
                        .WithMany("Partners")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Manifest", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Facility")
                        .WithMany("Manifests")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dwapi.Hts.Core.Domain.Subscriber", b =>
                {
                    b.HasOne("Dwapi.Hts.Core.Domain.Docket")
                        .WithMany("Subscribers")
                        .HasForeignKey("DocketId");
                });
#pragma warning restore 612, 618
        }
    }
}
