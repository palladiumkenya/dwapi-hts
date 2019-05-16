using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveLinkage : IRequest<Guid>
    {
        public IEnumerable<HtsClientLinkage> ClientLinkages { get; set; }

        public SaveLinkage( IEnumerable<HtsClientLinkage> clientLinkages)
        {

            ClientLinkages = clientLinkages;
        }
    }
}
