using CommonDomain.ValueObjects;
using System;

namespace StoresManagement.Domain
{
    public class Adress
    {
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Street { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
    }
}
