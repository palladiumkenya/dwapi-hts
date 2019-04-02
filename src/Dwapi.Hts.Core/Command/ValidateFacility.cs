using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class ValidateFacility: IRequest<MasterFacility>
    {
        public int SiteCode { get; }

        public ValidateFacility(int siteCode)
        {
            SiteCode = siteCode;
        }
    }
}