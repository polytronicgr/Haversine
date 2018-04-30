using System.Collections.Generic;
using Haversine.Maths;
using Haversine.Service.Models;

namespace Haversine.Service
{
    public class Locator : ILocator
    {
        private readonly double _radius;

        public Locator(double radius = 6372.8) // The radius of the earth (km).
        {
            _radius = radius;
        }

        public LocationDistance GetNearestTo(Coordinate coordinate, IEnumerable<Location> locations)
        {
            var locationDistance = new LocationDistance()
            {
                Distance = double.MaxValue
            };

            foreach (var location in locations)
            {
                var d = SphericalDistance(coordinate, location.Coordinate);

                if (d != 0 && d < locationDistance.Distance)
                {
                    locationDistance.Location = location;
                    locationDistance.Distance = d;
                }
            }

            return locationDistance;
        }

        public LocationDistance GetFarthestFrom(Coordinate coordinate, IEnumerable<Location> locations)
        {
            var locationDistance = new LocationDistance()
            {
                Distance = double.MinValue
            };

            foreach (var location in locations)
            {
                var d = SphericalDistance(coordinate, location.Coordinate);

                if (d != 0 && d > locationDistance.Distance)
                {
                    locationDistance.Location = location;
                    locationDistance.Distance = d;
                }
            }

            return locationDistance;
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
