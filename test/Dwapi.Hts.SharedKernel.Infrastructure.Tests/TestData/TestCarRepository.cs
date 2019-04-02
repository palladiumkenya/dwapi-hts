using System;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Dwapi.Hts.SharedKernel.Tests.TestData.Interfaces;
using Dwapi.Hts.SharedKernel.Tests.TestData.Models;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Hts.SharedKernel.Infrastructure.Tests.TestData
{
    
    public class TestCarRepository :BaseRepository<TestCar,Guid>,  ITestCarRepository
    {
        public TestCarRepository(DbContext context) : base(context)
        {
        }
    }
}