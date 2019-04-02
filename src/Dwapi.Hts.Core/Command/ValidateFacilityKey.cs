using System;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class ValidateFacilityKey: IRequest<bool>
    {
        public Guid Key { get; }

        public ValidateFacilityKey(Guid key)
        {
            Key = key;
        }
    }
}