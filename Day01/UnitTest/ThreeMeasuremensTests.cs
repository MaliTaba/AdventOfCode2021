using DayOne;
using Xunit;

namespace UnitTest
{
    public class ThreeMeasuremensTests
    {
        [Fact]
        public void ThreemeasurementReturnsValid()
        {
            // Arrange
            var inputVals = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            // Act
            var result = new ThreeMeasurement().GetGreaterSumCount(inputVals);

            // Assert
            Assert.Equal(5, result);
        }
    }
}
