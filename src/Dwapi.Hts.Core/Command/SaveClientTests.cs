using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveClientTests : IRequest<Guid>
    {
        public IEnumerable<HtsClientTests> HtsClientTestses { get; set; }

        public SaveClientTests( IEnumerable<HtsClientTests> clientdata)
        {

            HtsClientTestses = clientdata;
        }
    }
}
