using System;
using Dwapi.Hts.SharedKernel.Interfaces;
using Dwapi.Hts.SharedKernel.Tests.TestData.Models;

namespace Dwapi.Hts.SharedKernel.Tests.TestData.Interfaces
{
    public interface ITestCarRepository : IRepository<TestCar,Guid>
    {
        
    }
}