// See https://aka.ms/new-console-template for more information
using Five;
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "InputCoordinates.csv");
var inputCoordinates = CoordinateHelper.GetCoordinates(filePath);
Console.WriteLine("First part: " + OverlappingLines.CalculateOverlappingLines(inputCoordinates, 2, false));
Console.WriteLine("Second part: " + OverlappingLines.CalculateOverlappingLines(inputCoordinates, 2, true));
