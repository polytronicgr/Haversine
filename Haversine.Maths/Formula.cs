using System;

namespace Haversine.Maths
{
    public static class Formula
    {
        /// <summary>
        /// The haversine formula determines the great-circle distance between two points on a sphere
        /// given their longitudes and latitudes (in radians).
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Haversine_formula"/>
        /// <param name="r">The radius of the sphere.</param>
        /// <param name="lat1">The latitude of point 1.</param>
        /// <param name="long1">The longitude of point 1.</param>
        /// <param name="lat2">The latitude of point 2.</param>
        /// <param name="long2">The longitude of point 2.</param>
        /// <returns>The distance between the two points.</returns>
        public static double Haversine(double r, double lat1, double long1, double lat2, double long2)
        {
            var a = Hav(lat2 - lat1) + (Math.Cos(lat1) * Math.Cos(lat2) * Hav(long2 - long1));

            return 2.0 * r * Math.Asin(Math.Sqrt(a));
        }

        private static double Hav(double angle)
        {
            return (1.0 - Math.Cos(angle)) / 2.0;
        }
    }
}
