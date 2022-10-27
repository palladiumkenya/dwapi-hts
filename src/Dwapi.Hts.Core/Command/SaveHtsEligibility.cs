using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveHtsEligibility: IRequest<Guid>
    {
        public IEnumerable<HtsEligibilityExtract> HtsEligibility { get; set; }

        public SaveHtsEligibility( IEnumerable<HtsEligibilityExtract> htsEligibility)
        {

            HtsEligibility = htsEligibility;
        }
    }
}