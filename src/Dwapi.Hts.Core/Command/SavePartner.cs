using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SavePartner : IRequest<Guid>
    {
        public IEnumerable<HtsClientPartner> MasterPatientIndices { get; set; }

        public SavePartner( IEnumerable<HtsClientPartner> masterPatientIndices)
        {

            MasterPatientIndices = masterPatientIndices;
        }
    }
}
