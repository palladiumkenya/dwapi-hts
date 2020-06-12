using System;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveManifest : IRequest<Guid>
    {
        public Manifest Manifest { get; set; }
        public bool AllowSnapshot { get; set; }
        public SaveManifest()
        {
        }

        public SaveManifest(Manifest manifest)
        {
            Manifest = manifest;
        }
    }
}
