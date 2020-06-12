using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using NUnit.Framework;

namespace Dwapi.Hts.Core.Tests.Model
{
    [TestFixture]
    public class MasterFacilityTests
    {
        private readonly MasterFacility _masterFacility = new MasterFacility(12693, "Demo", "County");

        [Test]
        public void should_Take_Snap()
        {
            var snapA = _masterFacility.TakeSnap(new List<MasterFacility>());
            Assert.AreEqual(-10112693, snapA.Id);
            Assert.AreEqual(1, snapA.SnapshotVersion);
            Console.WriteLine(snapA.SnapInfo());

            _masterFacility.Id = 12693;
            var snapB = _masterFacility.TakeSnap(new List<MasterFacility>() {snapA});
            Assert.AreEqual(-10212693, snapB.Id);
            Assert.AreEqual(2, snapB.SnapshotVersion);
            Console.WriteLine(snapB.SnapInfo());

            _masterFacility.Id = 12693;
            var snapC = _masterFacility.TakeSnap(new List<MasterFacility>() {snapA, snapB});
            Assert.AreEqual(-10312693, snapC.Id);
            Assert.AreEqual(3, snapC.SnapshotVersion);
            Console.WriteLine(snapC.SnapInfo());
        }
    }
}
