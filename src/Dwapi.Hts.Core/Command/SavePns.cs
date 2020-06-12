using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SavePns : IRequest<Guid>
    {
        public IEnumerable<HtsPartnerNotificationServices> PartnerNotificationServices { get; set; }

        public SavePns( IEnumerable<HtsPartnerNotificationServices> partnernotificationservices)
        {

            PartnerNotificationServices = partnernotificationservices;
        }
    }
}