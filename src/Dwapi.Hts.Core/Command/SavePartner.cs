using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SavePartner : IRequest<Guid>
    {
        public IEnumerable<HtsClientPartner> ClientPartners { get; set; }

        public SavePartner( IEnumerable<HtsClientPartner> clientPartners)
        {

            ClientPartners = clientPartners;
        }
    }
}
