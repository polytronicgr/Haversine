using System.Collections.Generic;
using Haversine.Service.Models;

namespace Haversine.Service
{
    public interface ILocator
    {
        LocationDistance GetFarthestFrom(Coordinate coordinate, IEnumerable<Location> locations);
        LocationDistance GetNearestTo(Coordinate coordinate, IEnumerable<Location> locations);
    }
}