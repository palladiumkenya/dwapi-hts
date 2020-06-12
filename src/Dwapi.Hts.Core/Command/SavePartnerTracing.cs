using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SavePartnerTracing : IRequest<Guid>
    {
        public IEnumerable<HtsPartnerTracing> PartnerTracing { get; set; }

        public SavePartnerTracing( IEnumerable<HtsPartnerTracing> partnertracing)
        {

            PartnerTracing = partnertracing;
        }
    }
}