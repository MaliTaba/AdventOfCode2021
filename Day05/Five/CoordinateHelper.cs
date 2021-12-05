using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five
{
    public static class CoordinateHelper
    {
        public static Tuple<List<Coordinate>,int> GetCoordinates(string inputFile)
        {
            var maxValue = 0;

            var listCoordinates = new List<Coordinate>();
            
            var lines = File.ReadAllLines(inputFile);
            foreach (var line in lines)
            {
                var rowCoordinates = line.Split('-');
                var startCoordinate = rowCoordinates[0].Split(',')
                    .Select(item => int.Parse(item));

                var endCoordinate = rowCoordinates[1].Split(',')
                    .Select(item => int.Parse(item));

                maxValue = (new int[] { maxValue, startCoordinate.First(), startCoordinate.Last(), endCoordinate.First(), endCoordinate.Last() })
                    .Max();

                var lineCoordinate = new Coordinate()
                {
                    Start = Tuple.Create(startCoordinate.First(), startCoordinate.Last()),
                    End = Tuple.Create(endCoordinate.First(), endCoordinate.Last())
                };
                listCoordinates.Add(lineCoordinate);

            }
            return Tuple.Create(listCoordinates, maxValue);
        }
    }

    public class Coordinate
    {
        public Tuple<int, int> Start { get; set; }
        public Tuple<int, int> End { get; set; }

    }
}
