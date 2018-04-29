using System.Collections.Generic;
using System.Linq;
using Haversine.Data.Entities;

namespace Haversine.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HaversineDbContext _context;

        public LocationRepository(HaversineDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocation(string name)
        {
            return _context.Locations
                .Where(l => l.Name == name)
                .FirstOrDefault();
        }
    }
}
