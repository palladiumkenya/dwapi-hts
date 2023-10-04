using System;

namespace Dwapi.Hts.SharedKernel.Exceptions
{
    public class DwapiVersionNotAllowedException:Exception
    {
        public DwapiVersionNotAllowedException(string DwapiVersionSending):base($" ====> You're using DWAPI Version [{DwapiVersionSending}]. Older Versions of DWAPI are not allowed to send to NDWH. UPGRADE to the latest version 3.1.1.0 and RETRY")
        {
            
        }
    }
}