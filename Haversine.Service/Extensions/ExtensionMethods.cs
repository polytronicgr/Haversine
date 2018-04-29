using System.Collections.Generic;
using Haversine.Data.Entities;

namespace Haversine.Service.Extensions
{
    public static class ExtensionMethods
    {
        public static Models.Location ToModel(this Location location)
        {
            return new Models.Location
            {
                Name = location.Name,
                Coordinate = new Models.Coordinate
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                }
            };
        }

        public static IEnumerable<Models.Location> ToModel(this IEnumerable<Location> locations)
        {
            foreach (var location in locations)
            {
                yield return location.ToModel();
            }
        }
    }
}
