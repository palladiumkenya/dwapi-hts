using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveClient : IRequest<Guid>
    {
        public IEnumerable<HtsClient> Clients { get; set; }

        public SaveClient( IEnumerable<HtsClient> clients)
        {

            Clients = clients;
        }
    }
}
