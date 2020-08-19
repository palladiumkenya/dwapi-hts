using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.CommandHandler;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.Core.Service;
using Dwapi.Hts.Infrastructure.Data;
using Dwapi.Hts.Infrastructure.Data.Repository;
using Dwapi.Hts.SharedKernel.Tests.TestData;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;
using Z.Dapper.Plus;

namespace Dwapi.Hts.Core.Tests.Service
{
    public class HtsServiceTests
    {
        private ServiceProvider _serviceProvider;
        private List<HtsClient> _patientIndices;

        private List<HtsClient> _patientIndicesSiteB;
        private HtsContext _context;
        private IHtsService _htsService;
        private IManifestService _manifestService;
        private IMediator _mediator;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["ConnectionStrings:DwapiConnectionDev"];
            var liveSync = config["LiveSync"];


            DapperPlusManager.AddLicense("1755;700-ThePalladiumGroup", "2073303b-0cfc-fbb9-d45f-1723bb282a3c");
            if (!Z.Dapper.Plus.DapperPlusManager.ValidateLicense(out var licenseErrorMessage))
            {
                throw new Exception(licenseErrorMessage);
            }


            Uri endPointA = new Uri(liveSync); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPointA,
            };


            _serviceProvider = new ServiceCollection()
                .AddDbContext<HtsContext>(o => o.UseSqlServer(connectionString))

                .AddScoped<IDocketRepository, DocketRepository>()
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()

                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddScoped<IHtsClientRepository, HtsClientRepository>()
                .AddScoped<IHtsClientLinkageRepository, HtsClientLinkageRepository>()
                .AddScoped<IHtsClientPartnerRepository, HtsClientPartnerRepository>()

                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddScoped<IHtsClientRepository, HtsClientRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()

                .AddScoped<IHtsClientTestsRepository, HtsClientTestsRepository>()
                .AddScoped<IHtsClientTracingRepository, HtsClientTracingRepository>()
                .AddScoped<IHtsPartnerTracingRepository, HtsPartnerTracingRepository>()
                .AddScoped<IHtsPartnerNotificationServicesRepository, HtsPartnerNotificationServicesRepository>()
                .AddScoped<IHtsClientLinkageRepository, HtsClientLinkageRepository>()
                .AddScoped<IHtsHtsTestKitsRepository, HtsHtsTestKitsRepository>()

                .AddScoped<IHtsService, HtsService>()
                .AddScoped<ILiveSyncService, LiveSyncService>()
                .AddScoped<IManifestService, ManifestService>()
                .AddSingleton<HttpClient>(httpClient)
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();


            _context = _serviceProvider.GetService<HtsContext>();
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            _context.MasterFacilities.AddRange(TestDataFactory.TestMasterFacilities());
            var facilities = TestDataFactory.TestFacilities();
            _context.Facilities.AddRange(facilities);
            _context.SaveChanges();
            _patientIndices = TestDataFactory
                .TestClients(1, facilities.First(x => x.SiteCode == 1).Id);
            _patientIndicesSiteB =
                TestDataFactory
                    .TestClients(2, facilities.First(x => x.SiteCode == 2).Id);
        }

        [SetUp]
        public void SetUp()
        {
            _manifestService = _serviceProvider.GetService<IManifestService>();
            _mediator = _serviceProvider.GetService<IMediator>();
            _htsService = _serviceProvider.GetService<IHtsService>();
        }


        [Test]
        public void should_Process_After_Manifest()
        {
            var manifest = TestDataFactory.TestManifests(1).First();
            manifest.SiteCode = 1;
            var patients = _context.Clients.ToList();
            Assert.False(patients.Any());

            var id = _mediator.Send(new SaveManifest(manifest)).Result;
            _manifestService.Process();
            _htsService.Process(_patientIndices);
            Assert.True(_context.Clients.Any(x=>x.SiteCode==1));
        }

        [Test]
        public void should_Process_Recodrds_Without_Clients()
        {
            var manifests = TestDataFactory.TestManifests();
            manifests[0].SiteCode = 1;
            manifests[1].SiteCode = 2;
            var patients = _context.Clients.ToList();
            Assert.False(patients.Any());

            var id = _mediator.Send(new SaveManifest(manifests[0])).Result;
            _manifestService.Process();
            _htsService.Process(_patientIndices);
            Assert.True(_context.Clients.Any(x => x.SiteCode == 1));

            var id2 = _mediator.Send(new SaveManifest(manifests[1])).Result;
            _manifestService.Process();
            _htsService.Process(_patientIndicesSiteB);
            Assert.True(_context.Clients.Any(x => x.SiteCode == 1));
            Assert.True(_context.Clients.Any(x => x.SiteCode == 2));
        }
    }
}
