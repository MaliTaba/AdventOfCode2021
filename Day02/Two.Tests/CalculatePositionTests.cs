using System.Collections.Generic;
using Xunit;

namespace Two.Tests;

public class CalculatePositionTests
{
    [Fact]
    public void CalculateReturnsExpectedResult()
    {
        //Assign
        var givenDirections = new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>("forward", 5),
        new KeyValuePair<string, int>("down", 5),
        new KeyValuePair<string, int>("forward", 8),
        new KeyValuePair<string, int>("up", 3),
        new KeyValuePair<string, int>("down", 8),
        new KeyValuePair<string, int>("forward", 2)
        };

        // Act
        var result = CalculatePosition.Calculate(givenDirections);

        //Assert
        Assert.Equal(150, result);
    }

    [Fact]
    public void CalculateReturnsExpectedAimResult()
    {
        //Assign
        var givenDirections = new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>("forward", 5),
        new KeyValuePair<string, int>("down", 5),
        new KeyValuePair<string, int>("forward", 8),
        new KeyValuePair<string, int>("up", 3),
        new KeyValuePair<string, int>("down", 8),
        new KeyValuePair<string, int>("forward", 2)
        };

        // Act
        var result = CalculatePosition.CalculateAim(givenDirections);

        //Assert
        Assert.Equal(900, result);
    }
}
