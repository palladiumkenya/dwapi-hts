using System;

namespace Dwapi.Hts.SharedKernel.Exceptions
{
    public class SubscriberNotFoundException : Exception
    {
        public SubscriberNotFoundException(string name) : base($"Subscriber {name} not found")
        {

        }
    }
}