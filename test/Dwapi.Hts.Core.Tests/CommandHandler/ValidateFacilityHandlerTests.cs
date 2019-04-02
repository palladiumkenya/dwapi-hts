using System;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.CommandHandler;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Infrastructure.Data;
using Dwapi.Hts.Infrastructure.Data.Repository;
using Dwapi.Hts.SharedKernel.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Dwapi.Hts.Core.Tests.CommandHandler
{
    [TestFixture]
    public class ValidateFacilityHandlerTests
    {
        private ServiceProvider _serviceProvider;
        private IMediator _mediator;

        [OneTimeSetUp]
        public void Init()
        {
            _serviceProvider = new ServiceCollection()
                .AddDbContext<CbsContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();

            
           var  context = _serviceProvider.GetService<CbsContext>();
            context.MasterFacilities.Add(new MasterFacility(1, "XFacility", "XCounty"));
            context.SaveChanges();
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        [Test]
        public void should_Throw_Exception_Invalid_SiteCode()
        {
          var ex=  Assert.Throws<System.AggregateException>(() =>CheckMasterFacility(2));
            Assert.AreEqual(typeof(FacilityNotFoundException),ex.InnerException.GetType());
            Console.WriteLine($"{ex.InnerException.Message}");
        }

        [Test]
        public void should_return_Validated_Facility()
        {
            var masterFacility = CheckMasterFacility(1);
            Assert.NotNull(masterFacility);
            Console.WriteLine(masterFacility);
        }

        private  MasterFacility CheckMasterFacility(int code)
        {
            return _mediator.Send(new ValidateFacility(code)).Result;
        }
    }
}