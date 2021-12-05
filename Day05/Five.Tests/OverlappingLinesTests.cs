using System.IO;
using Xunit;

namespace Five.Tests;

public class OverlappingLinesTests
{
    [Theory]
    [InlineData(5, false)]
    [InlineData(12, true)]
    public void CalCulateOverlappingLinesOfAtLeastTwoReturnsExpectedResult(int expectedVal, bool includeDiagonals)
    {
        //Assign
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "InputCoordinates.csv");
        var inputCoordinates = CoordinateHelper.GetCoordinates(filePath);

        //Act
        var result = OverlappingLines.CalculateOverlappingLines(inputCoordinates, 2, includeDiagonals);

        //Assert
        Assert.Equal(expectedVal, result);
    }

    [Theory]
    [InlineData(false, "ExpectedBoard.csv")]
    [InlineData(true, "ExpectedBoard-diagnal.csv")]
    public void CoordinatesProducesExpectedBoard(bool includeDiagonals, string expectedFileName)
    {
        //Assign
        var coordinateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "InputCoordinates.csv");
        var inputCoordinates = CoordinateHelper.GetCoordinates(coordinateFilePath);

        var filepath = Path.Combine(Directory.GetCurrentDirectory(), expectedFileName);
        var expectedBoardData = File.ReadAllText(filepath);

        //Act
        var actualBoardData = OverlappingLines.CreateBoard(inputCoordinates, includeDiagonals);
        var actualBoardToString = OverlappingLines.ConvertBoardToString(actualBoardData);

        //Assert
        Assert.Equal(expectedBoardData, actualBoardToString);

    }
}