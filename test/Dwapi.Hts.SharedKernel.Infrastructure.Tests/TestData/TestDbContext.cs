using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Dwapi.Hts.SharedKernel.Tests.TestData.Models;
using EFCore.Seeder.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Hts.SharedKernel.Infrastructure.Tests.TestData
{
    public class TestDbContext:BaseContext
    {
        public DbSet<TestCar> TestCars { get; set; }
        public DbSet<TestModel> TestModels { get; set; }

        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        public override void EnsureSeeded()
        {
            TestCars.SeedDbSetIfEmpty($"{nameof(TestCar)}");
            TestModels.SeedDbSetIfEmpty($"{nameof(TestModel)}");
            base.EnsureSeeded();
        }
    }
}
