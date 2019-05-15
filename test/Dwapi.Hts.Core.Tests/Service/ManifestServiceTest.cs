using System.Linq;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.CommandHandler;
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

namespace Dwapi.Hts.Core.Tests.Service
{
    public class ManifestServiceTest
    {
        private ServiceProvider _serviceProvider;
        private HtsContext _context;
        private IManifestService _manifestService;
        private IMediator _mediator;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["ConnectionStrings:DwapiConnectionDev"];


            _serviceProvider = new ServiceCollection()
                .AddDbContext<HtsContext>(o => o.UseSqlServer(connectionString))
                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddScoped<IHtsClientRepository, HtsClientRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddScoped<IManifestService, ManifestService>()
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();


            _context = _serviceProvider.GetService<HtsContext>();
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            _context.MasterFacilities.AddRange(TestDataFactory.TestMasterFacilities());
            var facilities = TestDataFactory.TestFacilities();
            _context.Facilities.AddRange(facilities);
            _context.SaveChanges();
            _context.Clients.AddRange(TestDataFactory.TestMasterPatientIndices(1, facilities.First(x => x.SiteCode == 1).Id));
            _context.Clients.AddRange(TestDataFactory.TestMasterPatientIndices(2, facilities.First(x => x.SiteCode == 2).Id));
            _context.SaveChanges();

            //1,
        }

        [SetUp]
        public void SetUp()
        {
            _manifestService = _serviceProvider.GetService<IManifestService>();
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        [Test]
        public void should_Clear_By_Site()
        {
            var sitePatients = _context.Clients.ToList();
            Assert.True(sitePatients.Any(x=>x.SiteCode==1));
            Assert.True(sitePatients.Any(x => x.SiteCode == 2));

            var manifests = TestDataFactory.TestManifests(1);
            manifests.ForEach(x => x.SiteCode = 1);
            var id=_mediator.Send(new SaveManifest(manifests.First())).Result;
            _manifestService.Process();

            var remainingPatients = _context.Clients.ToList();
            Assert.False(remainingPatients.Any(x => x.SiteCode == 1));
            Assert.True(remainingPatients.Any(x => x.SiteCode == 2));
        }
    }
}
