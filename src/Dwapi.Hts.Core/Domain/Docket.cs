using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.SharedKernel.Model;
using Dwapi.Hts.SharedKernel.Utils;

namespace Dwapi.Hts.Core.Domain
{
    public class Docket:Entity<string>
    {
        public string Name { get; set; }
        public string Instance { get; set; }
        public ICollection<Subscriber> Subscribers { get; set; }=new List<Subscriber>();

        public Docket()
        {
        }
        public bool SubscriberExists(string name)
        {
            return Subscribers.Any(x => x.Name.IsSameAs(name));
        }

        public bool SubscriberAuthorized(string name, string authcode)
        {
            return Subscribers.Any(x => x.Name.IsSameAs(name) && x.AuthCode.IsSameAs(authcode));
        }
    }
}