using Dwapi.Hts.Core.Domain;
using NUnit.Framework;

namespace Dwapi.Hts.Core.Tests.Model
{
    [TestFixture]
    public class FacilityTests
    {
        [TestCase("IQCare","KenyaEMR")]
        [TestCase("KenyaEMR","IQCare")]
        public void should_confirm_EmrChange(string emr,string requestEmr)
        {
             var facility=new Facility(10000,"Demo");
             facility.Emr = emr;
             Assert.True(facility.EmrChanged(requestEmr));
        }

        [TestCase("","KenyaEMR")]
        [TestCase("KenyaEMR","")]
        [TestCase("","")]
        [TestCase("KenyaEMR","KenyaEMR")]
        public void should_confirm_EmrNotChange(string emr,string requestEmr)
        {
            var facility=new Facility(10000,"Demo");
            facility.Emr = emr;
            Assert.False(facility.EmrChanged(requestEmr));
        }
    }
}
