using Haversine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Haversine.Data
{
    public class HaversineDbContext : DbContext
    {
        public HaversineDbContext(DbContextOptions<HaversineDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}
