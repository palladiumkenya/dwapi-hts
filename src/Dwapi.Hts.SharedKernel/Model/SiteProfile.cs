using System;

namespace Dwapi.Hts.SharedKernel.Model
{
    public class SiteProfile
    {
        public int SiteCode { get; set; }
        public Guid FacilityId { get; set; }

        public SiteProfile()
        {
        }
        public SiteProfile(int siteCode, Guid facilityId)
        {
            SiteCode = siteCode;
            FacilityId = facilityId;
        }

       
    }
}