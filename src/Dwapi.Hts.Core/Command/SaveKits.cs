using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveKits : IRequest<Guid>
    {
        public IEnumerable<HtsTestKits> TestKits { get; set; }

        public SaveKits( IEnumerable<HtsTestKits> testkits)
        {

            TestKits = testkits;
        }
    }
}