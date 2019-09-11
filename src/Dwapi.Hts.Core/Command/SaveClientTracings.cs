using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveClientTracings: IRequest<Guid>
    {
        public IEnumerable<HtsClientTracing> ClientTracing { get; set; }

        public SaveClientTracings( IEnumerable<HtsClientTracing> clienttracing)
        {

            ClientTracing = clienttracing;
        }
    }
}