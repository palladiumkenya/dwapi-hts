using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveMpi : IRequest<Guid>
    {
        public IEnumerable<MasterPatientIndex> MasterPatientIndices { get; set; }

        public SaveMpi( IEnumerable<MasterPatientIndex> masterPatientIndices)
        {
  
            MasterPatientIndices = masterPatientIndices;
        }
    }
}