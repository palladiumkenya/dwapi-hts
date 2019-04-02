using System.Collections.Generic;
using System.Linq;
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

namespace Dwapi.Hts.Core.Tests.Service
{
    public class MpiServiceTests
    {
        private ServiceProvider _serviceProvider;
        private List<MasterPatientIndex> _patientIndices;
        private List<MasterPatientIndex> _patientIndicesSiteB;
        private HtsContext _context;
        private IMpiService _mpiService;
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
                .AddScoped<IMasterPatientIndexRepository, MasterPatientIndexRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddScoped<IMpiService, MpiService>()
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
            _patientIndices = TestDataFactory.TestMasterPatientIndices(1, facilities.First(x=>x.SiteCode==1).Id);
            _patientIndicesSiteB = TestDataFactory.TestMasterPatientIndices(2, facilities.First(x => x.SiteCode == 2).Id);
        }

        [SetUp]
        public void SetUp()
        {
            _manifestService = _serviceProvider.GetService<IManifestService>();
            _mediator = _serviceProvider.GetService<IMediator>();
            _mpiService = _serviceProvider.GetService<IMpiService>();

        }
        [Test]
        public void should_Process()
        {
            var patients = _context.MasterPatientIndices.ToList();
            Assert.False(patients.Any());

            _mpiService.Process(_patientIndices);
            var savedPatients = _context.MasterPatientIndices.ToList();
            Assert.True(savedPatients.Any());
        }

        [Test]
        public void should_Process_After_Manifest()
        {
            var manifests = TestDataFactory.TestManifests();
            manifests[0].SiteCode = 1;
            manifests[1].SiteCode = 2;
            var patients = _context.MasterPatientIndices.ToList();
            Assert.False(patients.Any());

            var id = _mediator.Send(new SaveManifest(manifests[0])).Result;
            _manifestService.Process();
            _mpiService.Process(_patientIndices);
            Assert.True(_context.MasterPatientIndices.Any(x=>x.SiteCode==1));

            var id2 = _mediator.Send(new SaveManifest(manifests[1])).Result;
            _manifestService.Process();
            _mpiService.Process(_patientIndicesSiteB);
            Assert.True(_context.MasterPatientIndices.Any(x => x.SiteCode == 1));
            Assert.True(_context.MasterPatientIndices.Any(x => x.SiteCode == 2));
        }
    }
}
