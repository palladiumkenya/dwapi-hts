using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveKits : IRequest<Guid>
    {
        public IEnumerable<HtsTestKits> HtsTestKits { get; set; }

        public SaveKits( IEnumerable<HtsTestKits> clientdata)
        {

            HtsTestKits = clientdata;
        }
    }
}