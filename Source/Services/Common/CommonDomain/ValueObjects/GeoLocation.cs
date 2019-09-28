using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.ValueObjects
{
    public class GeoLocation : ValueObject<GeoLocation>
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be in range from -90.0 to 90.0");

            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be in range from -90.0 to 90.0");

            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
