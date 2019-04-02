using System;

namespace Dwapi.Hts.SharedKernel.Exceptions
{
    public class DocketNotFoundException : Exception
    {
        public DocketNotFoundException(string docketId) : base($"Docket {docketId} does not exist")
        {

        }
    }
}