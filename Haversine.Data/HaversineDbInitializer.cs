using System.Collections.Generic;
using System.Linq;
using Haversine.Data.Entities;

namespace Haversine.Data
{
    public class HaversineDbInitializer
    {
        private readonly HaversineDbContext _context;

        public HaversineDbInitializer(HaversineDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Locations.Any())
            {
                _context.AddRange(_locations);
                _context.SaveChanges();
            }
        }

        private List<Location> _locations = new List<Location>()
        {
            new Location()
            {
                Name = "Chesterfield",
                Latitude = 53.235048,
                Longitude = -1.421629
            },
            new Location()
            {
                Name = "Sheffield",
                Latitude = 53.381129,
                Longitude = -1.470085
            },
            new Location()
            {
                Name = "Manchester",
                Latitude = 53.480759,
                Longitude = -2.242631
            },
            new Location()
            {
                Name = "London",
                Latitude = 51.507351,
                Longitude = -0.127758
            },
            new Location()
            {
                Name = "Leeds",
                Latitude = 53.800755,
                Longitude = -1.549077
            },
            new Location()
            {
                Name = "Nottingham",
                Latitude = 52.954783,
                Longitude = -1.158109
            },
            new Location()
            {
                Name = "Derby",
                Latitude = 52.92253,
                Longitude = -1.474619
            },
            new Location()
            {
                Name = "Matlock",
                Latitude = 53.137156,
                Longitude = -1.551774
            }
        };
    }
}
