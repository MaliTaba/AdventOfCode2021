// See https://aka.ms/new-console-template for more information
using Two;
Console.WriteLine("Day 2 results...");

var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.csv");
var inputData = File.ReadAllLines(filePath);
var data = new List<KeyValuePair<string, int>>();
foreach (var line in inputData)
{
    var arr = line.Split(" ");
    data.Add(new KeyValuePair<string, int> ( arr[0], int.Parse(arr[1]) ));
}

Console.WriteLine($"First case: " + CalculatePosition.Calculate(data));

Console.WriteLine($"First case: " + CalculatePosition.CalculateAim(data));
