using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SnapMasterFacility:IRequest<bool>
    {
        public int SiteCode { get; }

        public SnapMasterFacility(int siteCode)
        {
            SiteCode = siteCode;
        }
    }

}
