using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
                    DELETE FROM {nameof(HtsContext.Clients)} WHERE {nameof(HtsClient.FacilityId)} in ({ids}) AND {nameof(HtsClient.Project)} <> 'IRDO';
                    DELETE FROM {nameof(HtsContext.ClientLinkages)} WHERE {nameof(HtsClientLinkage.FacilityId)} in ({ids}) AND {nameof(HtsClientLinkage.Project)} <> 'IRDO';
                    DELETE FROM {nameof(HtsContext.ClientPartners)} WHERE {nameof(HtsClientPartner.FacilityId)} in ({ids}) AND {nameof(HtsClientPartner.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsClientTests)} WHERE {nameof(HtsClientTests.FacilityId)} in ({ids}) AND {nameof(HtsClientTests.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsClientTracing)} WHERE {nameof(HtsClientTracing.FacilityId)} in ({ids}) AND {nameof(HtsClientTracing.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsPartnerNotificationServices)} WHERE {nameof(HtsPartnerNotificationServices.FacilityId)} in ({ids}) AND {nameof(HtsPartnerNotificationServices.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsPartnerTracings)} WHERE {nameof(HtsPartnerTracing.FacilityId)} in ({ids}) AND {nameof(HtsPartnerTracing.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsTestKits)} WHERE {nameof(HtsTestKits.FacilityId)} in ({ids}) AND {nameof(HtsTestKits.Project)} <> 'IRDO';
                     DELETE FROM {nameof(HtsContext.HtsEligibilityExtract)} WHERE {nameof(HtsEligibilityExtract.FacilityId)} in ({ids}) AND {nameof(HtsEligibilityExtract.Project)} <> 'IRDO';

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

        public void ClearFacility(IEnumerable<Manifest> manifests, string project)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(HtsContext.Clients)} WHERE {nameof(HtsClient.FacilityId)} in ({ids}) AND {nameof(HtsClient.Project)}='{project}';
                    DELETE FROM {nameof(HtsContext.ClientLinkages)} WHERE {nameof(HtsClientLinkage.FacilityId)} in ({ids}) AND {nameof(HtsClientLinkage.Project)}='{project}';
                    DELETE FROM {nameof(HtsContext.ClientPartners)} WHERE {nameof(HtsClientPartner.FacilityId)} in ({ids}) AND {nameof(HtsClientPartner.Project)}='{project}';
                     DELETE FROM {nameof(HtsContext.HtsClientTests)} WHERE {nameof(HtsClientTests.FacilityId)} in ({ids}) AND {nameof(HtsClientTests.Project)}='{project}';
                     DELETE FROM {nameof(HtsContext.HtsClientTracing)} WHERE {nameof(HtsClientTracing.FacilityId)} in ({ids}) AND {nameof(HtsClientTracing.Project)}='{project}';
                     DELETE FROM {nameof(HtsContext.HtsPartnerNotificationServices)} WHERE {nameof(HtsPartnerNotificationServices.FacilityId)} in ({ids}) AND {nameof(HtsPartnerNotificationServices.Project)}='{project}';
                     DELETE FROM {nameof(HtsContext.HtsPartnerTracings)} WHERE {nameof(HtsPartnerTracing.FacilityId)} in ({ids}) AND {nameof(HtsPartnerTracing.Project)}='{project}';
                     DELETE FROM {nameof(HtsContext.HtsTestKits)} WHERE {nameof(HtsTestKits.FacilityId)} in ({ids}) AND {nameof(HtsTestKits.Project)}='${project}';
                     DELETE FROM {nameof(HtsContext.HtsEligibilityExtract)} WHERE {nameof(HtsTestKits.FacilityId)} in ({ids}) AND {nameof(HtsEligibilityExtract.Project)}='${project}';

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

        public IEnumerable<Manifest> GetStaged(int siteCode)
        {
            var ctt = Context as HtsContext;
            var manifests = DbSet.AsNoTracking().Where(x => x.Status == ManifestStatus.Staged && x.SiteCode == siteCode)
                .ToList();

            foreach (var manifest in manifests)
            {
                manifest.Cargoes = ctt.Cargoes.AsNoTracking()
                    .Where(x => x.Type != CargoType.Patient && x.ManifestId == manifest.Id).ToList();
            }

            return manifests;
        }

        public async Task EndSession(Guid session)
        {
            var end = DateTime.Now;
            var sql = $"UPDATE {nameof(HtsContext.Manifests)} SET [{nameof(Manifest.End)}]=@end WHERE [{nameof(Manifest.Session)}]=@session";
            await Context.Database.GetDbConnection().ExecuteAsync(sql, new {session, end});
        }

        public IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session)
        {
            var sql = $"SELECT * FROM {nameof(HtsContext.Manifests)} WHERE [{nameof(Manifest.Session)}]=@session";
            var manifests = Context.Database.GetDbConnection().Query<Manifest>(sql,new{session}).ToList();
            return manifests.Select(x => new HandshakeDto()
            {
                Id = x.Id, End = x.End, Session = x.Session, Start = x.Start
            });
        }
    }
}
