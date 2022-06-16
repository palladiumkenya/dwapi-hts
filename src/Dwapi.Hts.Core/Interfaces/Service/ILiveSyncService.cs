using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Domain.Dto;

namespace Dwapi.Hts.Core.Interfaces.Service
{
    public interface ILiveSyncService
    {
        void SyncManifest(Manifest manifest,int clientCount);
        void SyncStats(List<Guid> facilityId);
       void SyncMetrics(List<MetricDto> metrics);
       Task SyncHandshake(List<HandshakeDto> handshakeDtos);
    }
}
