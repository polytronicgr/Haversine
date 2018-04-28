using System;

namespace Haversine.Maths
{
    public static class ExtensionMethods
    {
        public static double ToRadians(this double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        public static double ToDegrees(this double radians)
        {
            return radians * 180.0 / Math.PI;
        }
    }
}
