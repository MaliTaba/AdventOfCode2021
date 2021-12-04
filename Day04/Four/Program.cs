// See https://aka.ms/new-console-template for more information
using Four;

Console.WriteLine("Hello, World!");
var boardsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Boards.csv");
var boardsData = BingoSubsystem.ReadBoardsFromFile(boardsFilePath);

var calledNumbersFilePath = Path.Combine(Directory.GetCurrentDirectory(), "CalledNumbers.csv");
var calledNumbersCsv = File.ReadAllLines(calledNumbersFilePath).First();

Console.WriteLine("First part: " + BingoSubsystem.CalculateScore(boardsData, calledNumbersCsv, 1));

Console.WriteLine("Second part: " + BingoSubsystem.CalculateScore(boardsData, calledNumbersCsv, -1));
