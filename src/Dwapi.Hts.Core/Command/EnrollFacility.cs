using System;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class EnrollFacility : IRequest<Guid>
    {
        public int SiteCode { get; }
        public string Name { get;  }
        public int MflCode { get; }

        public EnrollFacility(int siteCode, string name)
        {
            SiteCode = siteCode;
            Name = name;
        }

        public EnrollFacility(int siteCode, string name, int mflCode):this(siteCode,name)
        {
            MflCode = mflCode;
        }
    }
}