using System.Collections.Generic;
using Haversine.Data.Entities;

namespace Haversine.Data
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocation(string name);
    }
}