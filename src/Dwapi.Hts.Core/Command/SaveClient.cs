using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveClient : IRequest<Guid>
    {
        public IEnumerable<HtsClient> MasterPatientIndices { get; set; }

        public SaveClient( IEnumerable<HtsClient> masterPatientIndices)
        {

            MasterPatientIndices = masterPatientIndices;
        }
    }
}
