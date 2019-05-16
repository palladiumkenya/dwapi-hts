using System.Reflection;
using CsvHelper.Configuration;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using EFCore.Seeder.Configuration;
using EFCore.Seeder.Extensions;
using Microsoft.EntityFrameworkCore;
using Z.Dapper.Plus;

namespace Dwapi.Hts.Infrastructure.Data
{
    public class HtsContext:BaseContext
    {
        public DbSet<Docket> Dockets { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<MasterFacility> MasterFacilities { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<HtsClient> Clients { get; set; }
        public DbSet<HtsClientLinkage> ClientLinkages { get; set; }
        public DbSet<HtsClientPartner> ClientPartners { get; set; }

        public HtsContext(DbContextOptions<HtsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DapperPlusManager.Entity<Docket>().Key(x => x.Id).Table($"{nameof(HtsContext.Dockets)}");
            DapperPlusManager.Entity<Subscriber>().Key(x => x.Id).Table($"{nameof(HtsContext.Subscribers)}");

            DapperPlusManager.Entity<MasterFacility>().Key(x => x.Id).Table($"{nameof(HtsContext.MasterFacilities)}");

            DapperPlusManager.Entity<Facility>().Key(x => x.Id).Table($"{nameof(HtsContext.Facilities)}");
            DapperPlusManager.Entity<Manifest>().Key(x => x.Id).Table($"{nameof(HtsContext.Manifests)}");
            DapperPlusManager.Entity<Cargo>().Key(x => x.Id).Table($"{nameof(HtsContext.Cargoes)}");
            DapperPlusManager.Entity<HtsClient>().Key(x => x.Id).Table($"{nameof(HtsContext.Clients)}");
            DapperPlusManager.Entity<HtsClientLinkage>().Key(x => x.Id).Table($"{nameof(HtsContext.ClientLinkages)}");
            DapperPlusManager.Entity<HtsClientPartner>().Key(x => x.Id).Table($"{nameof(HtsContext.ClientPartners)}");

        }

        public override void EnsureSeeded()
        {
            var csvConfig = new Configuration()
            {
                Delimiter = "|"
            };

            SeederConfiguration.ResetConfiguration(csvConfig, null, typeof(HtsContext).GetTypeInfo().Assembly);

        //    MasterFacilities.SeedDbSetIfEmpty($"{nameof(MasterFacility)}");
            Dockets.SeedDbSetIfEmpty($"{nameof(Docket)}");
            SaveChanges();
            Subscribers.SeedDbSetIfEmpty($"{nameof(Subscriber)}");
            SaveChanges();
        }
    }
}
