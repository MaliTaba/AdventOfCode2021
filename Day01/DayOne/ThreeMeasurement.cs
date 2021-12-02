namespace DayOne
{
    public class ThreeMeasurement
    {
        private int _currentSum;
        public int GetGreaterSumCount(int[] measurements)
        {
            var count = 0;
            _currentSum = CalculateSum(measurements, 0);


            for (int i = 1; i < measurements.Length - 2; i++)
            {
                var currentThreeMeasurementDepth = CalculateSum(measurements, i);
                if (_currentSum < currentThreeMeasurementDepth)
                {
                    count++;
                }

                _currentSum = CalculateSum(measurements, i);
            }
            return count;
        }

        private static int CalculateSum(int[] measurements, int i)
        {
            return measurements[i] + measurements[i + 1] + measurements[i + 2];
        }

    }
}
