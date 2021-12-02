namespace DayOne
{
    public static class SeaMeasurement
    {
        public static int Getcount(int[] searFMeasurement)
        {
            var count = 0;
            var prevMeasure = searFMeasurement[0];
            for (int i = 1; i < searFMeasurement.Length; i++)
            {
                if (searFMeasurement[i] > prevMeasure)
                {
                    count++;
                }

                prevMeasure = searFMeasurement[i];
            }

            return count;
        }
    }
}
