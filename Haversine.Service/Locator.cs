using System.Collections.Generic;
using Haversine.Maths;
using Haversine.Service.Models;

namespace Haversine.Service
{
    public class Locator
    {
        private readonly double _radius;

        public Locator(double radius = 6372.8) // The radius of the earth (km).
        {
            _radius = radius;
        }

        public Location GetNearestTo(Location origin, IEnumerable<Location> locations)
        {
            var destination = origin;
            double distance = double.MaxValue;

            foreach (var location in locations)
            {
                var d = SphericalDistance(origin.Coordinate, location.Coordinate);

                if (d != 0 && d < distance)
                {
                    distance = d;
                    destination = location;
                }
            }

            return destination;
        }

        public Location GetFarthestFrom(Location origin, IEnumerable<Location> locations)
        {
            var destination = origin;
            double distance = double.MinValue;

            foreach (var location in locations)
            {
                var d = SphericalDistance(origin.Coordinate, location.Coordinate);

                if (d != 0 && d > distance)
                {
                    distance = d;
                    destination = location;
                }
            }

            return destination;
        }

        private double SphericalDistance(Coordinate orig, Coordinate dest)
        {
            var lat1 = orig.Latitude.ToRadians();
            var long1 = orig.Longitude.ToRadians();
            var lat2 = dest.Latitude.ToRadians();
            var long2 = dest.Longitude.ToRadians();

            return Formula.Haversine(_radius, lat1, long1, lat2, long2);
        }
    }
}
