using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Four.Tests;

public class BingoSubsystemTests
{
    [Fact]
    public void CalculateScoreReturnsValidValueForFirstWinner()
    {
        //Assign
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Boards.csv");
        var boardsData = BingoSubsystem.ReadBoardsFromFile(filePath);

        var calledNumbersPath = Path.Combine(Directory.GetCurrentDirectory(), "CalledNumbers.csv");
        var calledNumbersCsv = File.ReadAllLines(calledNumbersPath).First();

        //Act
        int result = BingoSubsystem.CalculateScore(boardsData, calledNumbersCsv, 1);

        //Assert
        Assert.Equal(4512, result);
    }

    //[Fact]
    //public void CalculateScoreReturnsValidValueForSecondWinner()
    //{
    //    //Assign
    //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Boards.csv");
    //    var boardsData = BingoSubsystem.ReadBoardsFromFile(filePath);

    //    var calledNumbersPath = Path.Combine(Directory.GetCurrentDirectory(), "CalledNumbers.csv");
    //    var calledNumbersCsv = File.ReadAllLines(calledNumbersPath).First();

    //    //Act
    //    int result = BingoSubsystem.CalculateScore(boardsData, calledNumbersCsv, 2);

    //    //Assert
    //    Assert.Equal(1924, result);
    //}

    [Fact]
    public void CalculateScoreReturnsValidValueForLastWinner()
    {
        //Assign
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Boards.csv");
        var boardsData = BingoSubsystem.ReadBoardsFromFile(filePath);

        var calledNumbersPath = Path.Combine(Directory.GetCurrentDirectory(), "CalledNumbers.csv");
        var calledNumbersCsv = File.ReadAllLines(calledNumbersPath).First();

        //Act
        int result = BingoSubsystem.CalculateScore(boardsData, calledNumbersCsv, -1);

        //Assert
        Assert.Equal(1924, result);

    }


    [Fact]
    public void CalculateSumUnmarkedNumbers_ReturnsValidVal()
    {
        int[] input = { 7, 4, 9, 5 };
        var result = new BingoSubsystem().CalculateSumUnmarkedNumbers(input);
        Assert.Equal(25, result);
    }
}