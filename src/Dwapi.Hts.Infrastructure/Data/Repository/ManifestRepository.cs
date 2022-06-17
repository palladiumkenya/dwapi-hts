using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Domain;
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
        
        public int GetPatientCount(Guid id)
        {
            var ctt = Context as HtsContext;
            var cargo = ctt.Cargoes.FirstOrDefault(x => x.ManifestId == id && x.Type == CargoType.Patient);
            if (null != cargo)
                return cargo.Items.Split(",").Length;

            return 0;
        }

        public IEnumerable<Manifest> GetStaged()
        {
            var ctt = Context as HtsContext;
            var manifests= DbSet.AsNoTracking().Where(x => x.Status == ManifestStatus.Staged).ToList();

            foreach (var manifest in manifests)
            {
                manifest.Cargoes = ctt.Cargoes.AsNoTracking()
                    .Where(x => x.Type != CargoType.Patient && x.ManifestId == manifest.Id).ToList();
            }

            return manifests;

        }
    }
}
