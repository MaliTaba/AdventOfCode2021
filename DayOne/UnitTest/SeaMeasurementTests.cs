using DayOne;
using Xunit;


namespace UnitTest
{
    public class SeaMeasurementTests
    {
        [Fact]
        public void TestDefaultvalues()
        {
            //Assign
            var inputVals = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            
            //Act
            var results = SeaMeasurement.Getcount(inputVals);
            
            //Assert
            Assert.Equal(results,7);
        }

    }
}
