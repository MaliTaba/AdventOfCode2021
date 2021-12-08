namespace Six
{
    public class GrowthRate
    {
        public static long Calculate()
        {
            var input = File.ReadAllText("input.txt").Split(",").Select(int.Parse).ToArray();

            var allFish = new Dictionary<int, long>()
{
    {0, 0},
    {1, 0},
    {2, 0},
    {3, 0},
    {4, 0},
    {5, 0},
    {6, 0},
    {7, 0},
    {8, 0},
};

            foreach (var fish in input)
            {
                allFish[fish]++;
            }

            // 80 days => 380612

            // 256 days => 1710166656900
            
            for (var day = 0; day < 80;  day++)
            {
                var fishToAdd = allFish[0];

                for (var i = 1; i <= 8; i++)
                {
                    allFish[i - 1] = allFish[i];
                }

                allFish[8] = fishToAdd;
                allFish[6] += fishToAdd;
            }

            long answer = 0;
            foreach (var index in allFish)
            {
                answer += allFish[index.Key];
            }

            return answer;

        }
    }
}
