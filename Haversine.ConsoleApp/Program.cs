using System;
using Haversine.Maths;

namespace Haversine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Haversine!");

            const double radius = 6372.8; // The radius of the earth (km).

            var origin = new Coordinate { Latitude = 0.0, Longitude = 0.0 };
            var destination = new Coordinate { Latitude = 0.0, Longitude = 0.0 };

            var distance = Formula.Haversine(radius, origin.Latitude, origin.Longitude, destination.Latitude, destination.Longitude);

            Console.WriteLine($"Distance: {distance} (km)");

            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
