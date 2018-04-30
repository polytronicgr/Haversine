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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Haversine;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}
