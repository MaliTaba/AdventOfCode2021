using System.IO;
using Xunit;

namespace Three.Tests;

public class PowerConsumptionTests
{
    [Fact]
    public void PowerConsumptionRetrnsValidResult()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.csv");
        var inputData = File.ReadAllLines(filePath);
        
        var res = PowerConsumption.Calculate(inputData);

        Assert.Equal(198, res);
    }

    [Fact]
    public void TestSubmarineLifeSupport()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.csv");
        var inputData = File.ReadAllLines(filePath);

        var res = new SubmarineLifeSupport().Calculate(inputData);

        Assert.Equal(230, res);
    }
}