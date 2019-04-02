using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveMpi : IRequest<Guid>
    {
        public IEnumerable<HtsClient> MasterPatientIndices { get; set; }

        public SaveMpi( IEnumerable<HtsClient> masterPatientIndices)
        {
  
            MasterPatientIndices = masterPatientIndices;
        }
    }
}