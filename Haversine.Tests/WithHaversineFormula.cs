using Haversine.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haversine.Tests
{
    [TestClass]
    public class WithHaversineFormula
    {
        [TestMethod]
        public void AndZeroValuesReturnsZero()
        {
            // Arrange
            double r = 0.0;
            double lat1 = 0.0;
            double long1 = 0.0;
            double lat2 = 0.0;
            double long2 = 0.0;

            // Act
            double d = Formula.Haversine(r, lat1, long1, lat2, long2);

            // Assert
            Assert.AreEqual(0, d);
        }
    }
}
