using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
    public class FuelConsumption
    {
        public Tuple<int,int> CalculateFuel()
        {
            var testInput = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            // for this test the position 2 with cost of 37

            var puzzleInput = File.ReadAllText("PuzzleInput.txt").Split(",").Select(n => int.Parse(n)).ToArray();
            // First part: 364898
            // second: 104149091

            var leastFuelBenchmarkConstantRate = GetTotalFuelPerPositionConstantRate(puzzleInput, puzzleInput[0]);

            foreach (var item in puzzleInput)
            {
                int totalFuelPerPositionConstantRate = GetTotalFuelPerPositionConstantRate(puzzleInput, item);
                if (leastFuelBenchmarkConstantRate > totalFuelPerPositionConstantRate)
                {
                    leastFuelBenchmarkConstantRate = totalFuelPerPositionConstantRate;
                }

            }

            var leastBenchMarkExpo = GetTotalFuelPerPositionExponentialRate(puzzleInput, puzzleInput[0]);
            foreach (var item in puzzleInput)
            {
                var secPart = GetTotalFuelPerPositionExponentialRate(puzzleInput, item);
                if (secPart < leastBenchMarkExpo)
                {
                    leastBenchMarkExpo = secPart;
                }

            }

            return Tuple.Create(leastFuelBenchmarkConstantRate, leastBenchMarkExpo);
        }

        int CalcFuel(int diff)
        {
            return (diff * (diff + 1)) / 2;
        }

        private int GetTotalFuelPerPositionExponentialRate(int[] allPositions, int targetPosition)
        {
            var count = 0;
            foreach (var position in allPositions)
            {
                var diff = position - targetPosition;
                
                if (diff < 0) { diff *= -1; }
                
                count += CalcFuel(diff);
            }

            return count;
        }

        private int GetTotalFuelPerPositionConstantRate(int[] allPositions, int targetPosition)
        {
            var count = 0;
            foreach (var position in allPositions)
            {
                var diff = position - targetPosition;
                if (diff < 0) { diff *= -1; }
                count += diff;
            }

            return count;
        }
    }
}
