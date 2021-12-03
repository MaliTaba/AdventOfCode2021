namespace Three
{
    public class SubmarineLifeSupport
    {
        public decimal Calculate(string[] binStrings)
        {
            var oxygenGeneratorRating = GetOxygenGeneratorRating(binStrings);
            var c02ScrubberRating = GetC02ScrubberRating(binStrings);

            return oxygenGeneratorRating * c02ScrubberRating;
        }

        private decimal GetOxygenGeneratorRating(string[] binStrings)
        {
            var binList = binStrings.ToList();
            var oxRateBin = "";
            var currentList = binList;

            var currentIndex = 0;
            while (currentList.Count > 0)
            {
                if (currentList.Count == 1)
                {
                    oxRateBin = currentList.LastOrDefault();
                    break;
                }

                var counts = CountOneAndZero(currentList, currentIndex);

                if (counts.Item1 >= counts.Item2)
                {
                    currentList = UpdateListContainingItem(currentList, '1', currentIndex);
                }
                else
                {
                    currentList = UpdateListContainingItem(currentList, '0', currentIndex);
                }

                if (currentIndex < binStrings?.FirstOrDefault()?.Length)
                {
                    currentIndex++;
                }
            }

            return Convert.ToInt32(oxRateBin, 2);
        }

        private List<string> UpdateListContainingItem(List<string> currentList, char itemToKeep, int currentIndex)
        {

            return currentList.Where(item => item[currentIndex] == itemToKeep).ToList();
        }

        private Tuple<int, int> CountOneAndZero(List<string> currentList, int i)
        {
            var oneCount = 0;
            var zeroCount = 0;

            foreach (var item in currentList)
            {
                if (item[i].Equals('1'))
                {
                    oneCount++;
                }
                else if (item[i].Equals('0'))
                {
                    zeroCount++;
                }
            }
            return new Tuple<int, int>(oneCount, zeroCount);
        }


        private decimal GetC02ScrubberRating(string[] binStrings)
        {
            var binList = binStrings.ToList();
            var coRateBin = "";

            var currentList = binList;

            var currentIndex = 0;
            while (currentList.Count > 0)
            {
                if (currentList.Count == 1)
                {
                    coRateBin = currentList.LastOrDefault();
                    break;
                }

                var counts = CountOneAndZero(currentList, currentIndex);

                if (counts.Item1 < counts.Item2)
                {
                    currentList = UpdateListContainingItem(currentList, '1', currentIndex);
                }
                else
                {
                    currentList = UpdateListContainingItem(currentList, '0', currentIndex);
                }

                if (currentIndex < binStrings?.FirstOrDefault()?.Length)
                {
                    currentIndex++;
                }
            }

            return Convert.ToInt32(coRateBin, 2);
        }
    }
}
