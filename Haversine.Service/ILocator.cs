using System.Collections.Generic;
using Haversine.Service.Models;

namespace Haversine.Service
{
    public interface ILocator
    {
        LocationDistance GetNearestTo(Coordinate coordinate, IEnumerable<Location> locations);
        LocationDistance GetFarthestFrom(Coordinate coordinate, IEnumerable<Location> locations);
    }
}