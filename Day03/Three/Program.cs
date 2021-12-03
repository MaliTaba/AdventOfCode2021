// See https://aka.ms/new-console-template for more information
using Three;

Console.WriteLine("Hello, World!");
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.csv");
var inputData = File.ReadAllLines(filePath);
Console.WriteLine("Part1: " + PowerConsumption.Calculate(inputData));

Console.WriteLine("Part2: " + new SubmarineLifeSupport().Calculate(inputData));

