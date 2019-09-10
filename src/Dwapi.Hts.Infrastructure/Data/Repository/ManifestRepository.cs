using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class ManifestRepository : BaseRepository<Manifest, Guid>, IManifestRepository
    {
        public ManifestRepository(HtsContext context) : base(context)
        {
        }

        public void ClearFacility(IEnumerable<Manifest> manifests)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(HtsContext.Clients)} WHERE {nameof(HtsClient.FacilityId)} in ({ids});
                    DELETE FROM {nameof(HtsContext.ClientLinkages)} WHERE {nameof(HtsClientLinkage.FacilityId)} in ({ids});
                    DELETE FROM {nameof(HtsContext.ClientPartners)} WHERE {nameof(HtsClientPartner.FacilityId)} in ({ids});
                     DELETE FROM {nameof(HtsContext.HtsClientTests)} WHERE {nameof(HtsClientTests.FacilityId)} in ({ids});
                     DELETE FROM {nameof(HtsContext.HtsClientTracing)} WHERE {nameof(HtsClientTracing.FacilityId)} in ({ids});
                     DELETE FROM {nameof(HtsContext.HtsPartnerNotificationServices)} WHERE {nameof(HtsPartnerNotificationServices.FacilityId)} in ({ids});
                     DELETE FROM {nameof(HtsContext.HtsPartnerTracings)} WHERE {nameof(HtsPartnerTracing.FacilityId)} in ({ids});
                     DELETE FROM {nameof(HtsContext.HtsTestKits)} WHERE {nameof(HtsTestKits.FacilityId)} in ({ids});
                 "
                );

            var mids = string.Join(',', manifests.Select(x => $"'{x.Id}'"));
            ExecSql(
                $@"
                    UPDATE
                        {nameof(HtsContext.Manifests)}
                    SET
                        {nameof(Manifest.Status)}={(int)ManifestStatus.Processed},
                        {nameof(Manifest.StatusDate)}=GETDATE()
                    WHERE
                        {nameof(Manifest.Id)} in ({mids})");
        }

        public int GetPatientCount(Guid id)
        {
            var ctt = Context as HtsContext;
            var cargo = ctt.Cargoes.FirstOrDefault(x => x.ManifestId == id && x.Type == CargoType.Patient);
            if (null != cargo)
                return cargo.Items.Split(",").Length;

            return 0;
        }
    }
}
