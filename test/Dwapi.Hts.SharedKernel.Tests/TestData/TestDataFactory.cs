using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Tests.TestData.Models;
using FizzWare.NBuilder;

namespace Dwapi.Hts.SharedKernel.Tests.TestData
{
    public class TestDataFactory
    {
        public static List<MasterFacility> TestMasterFacilities(int count = 2)
        {
            var facilities = Builder<MasterFacility>.CreateListOfSize(count)
                .Build()
                .ToList();

            int n = 0;
            foreach (var facility in facilities)
            {
                n++;
                facility.Id = n;
            }
            return facilities;
        }

        public static List<Facility> TestFacilities(int count = 2)
        {
            var facilities = Builder<Facility>.CreateListOfSize(count)
                .Build()
                .ToList();

            int n = 0;
            foreach (var facility in facilities)
            {
                n++;
                facility.SiteCode = n;
                facility.MasterFacilityId = n;
            }
            return facilities;
        }

        public static List<Facility> TestFacilityWithPatients(int count = 2, int childcount = 3)
        {
            var facilities = Builder<Facility>.CreateListOfSize(count)
                .Build()
                .ToList();

            int n = 0;
            foreach (var facility in facilities)
            {
                n++;
                facility.SiteCode = n;
                facility.Clients = Builder<HtsClient>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.ClientTestses = Builder<HtsClientTests>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.Linkages = Builder<HtsClientLinkage>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.ClientTracings = Builder<HtsClientTracing>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.PartnerNotifications = Builder<HtsPartnerNotificationServices>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.HtsPartnerTracings = Builder<HtsPartnerTracing>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
                facility.Kitses = Builder<HtsTestKits>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.FacilityId == facility.Id)
                    .Build()
                    .ToList();
            }
            return facilities;
        }

        public static List<HtsClient> TestMasterPatientIndices(int siteCode, Guid facilityId, int count = 5)
        {
            var patientIndices = Builder<HtsClient>.CreateListOfSize(count)
                .All().With(x => x.SiteCode = siteCode)
                .With(x => x.FacilityId = facilityId)
                .Build()
                .ToList();
            patientIndices.Take(2).ToList().ForEach(p => p.Project = "IRDO");
            return patientIndices;
        }

        public static List<Manifest> TestManifests(int count = 2, int childcount = 3)
        {
            var manifests = Builder<Manifest>.CreateListOfSize(count)
                .All().With(x=>x.Status=ManifestStatus.Staged)
                .Build()
                .ToList();

            foreach (var manifest in manifests)
            {
                manifest.Id=Guid.NewGuid();
                manifest.Cargoes = Builder<Cargo>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.ManifestId == manifest.Id)
                    .Build()
                    .ToList();
            }
            return manifests;
        }

        public static List<Docket> TestDockets(int count= 2, int childcount = 3)
        {
           var dockets=   Builder<Docket>.CreateListOfSize(count)
                .Build()
                .ToList();

            foreach (var docket in dockets)
            {
                docket.Subscribers= Builder<Subscriber>.CreateListOfSize(childcount)
                    .All()
                    .With(x => x.DocketId == docket.Id)
                    .Build()
                    .ToList();
            }
            return dockets;
        }

        public static List<TestCar> TestCars(int count=2)
        {
            return Builder<TestCar>.CreateListOfSize(count)
                .Build()
                .ToList();
        }
        public static List<TestModel> TestModels(int count = 2)
        {
            return Builder<TestModel>.CreateListOfSize(count)
                .Build()
                .ToList();
        }
        public static List<TestCar> TestCarsWithModel(int count = 2,int childcount=3)
        {
            var cars= Builder<TestCar>.CreateListOfSize(count)
                .Build()
                .ToList();
            foreach (var testCar in cars)
            {
                testCar.Models = Builder<TestModel>.CreateListOfSize(childcount)
                    .All()
                    .With(x=>x.TestCarId==testCar.Id)
                    .Build()
                    .ToList();
            }
            return cars;
        }
    }
}
