// See https://aka.ms/new-console-template for more information
using Seven;
var fc = new FuelConsumption();
Console.WriteLine("First part: "+ fc.CalculateFuel().Item1);

Console.WriteLine("Second part: " + fc.CalculateFuel().Item2);

