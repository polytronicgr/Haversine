using System;
using Haversine.Data;
using Haversine.Service;
using Haversine.Service.Extensions;

namespace Haversine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Haversine!");
            Console.WriteLine();

            const double radius = 6372.8; // The radius of the earth (km).

            HaversineDbContext context = new HaversineDbContext();
            ILocationRepository repository = new LocationRepository(context);

            HaversineDbInitializer initializer = new HaversineDbInitializer(context);

            initializer.Seed();

            var origin = repository.GetLocation("Chesterfield").ToModel();

            Console.WriteLine($"Origin: {origin.Name}");

            var locations = repository.GetAllLocations().ToModel();

            var locator = new Locator(radius);

            var nearest = locator.GetNearestTo(origin, locations);
            var farthest = locator.GetFarthestFrom(origin, locations);

            Console.WriteLine($"Nearest: {nearest.Name}");
            Console.WriteLine($"Farthest: {farthest.Name}");

            Console.WriteLine();
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
