using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;

namespace Dwapi.Hts.Core.Interfaces.Service
{
    public interface ILiveSyncService
    {
        void SyncManifest(Manifest manifest,int clientCount);
        void SyncStats(List<Guid> facilityId);
    }
}
