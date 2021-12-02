namespace Two
{
    public class CalculatePosition
    {

        public static int CalculateAim(List<KeyValuePair<string, int>> positionInfo)
        {
            int aim = 0;
            var horizonal = 0;
            var depth =0;
            foreach (var item in positionInfo)
            {
                switch (item.Key)
                {
                    case "down":
                        aim += item.Value;
                        break;
                    case "up":
                        aim -= item.Value;
                        break;
                    case "forward":
                        horizonal+=item.Value;
                        depth += aim * item.Value;
                        break;
                }
            }

            return horizonal * depth;

        }

        public static int Calculate(List<KeyValuePair<string, int>> positionInfo)
        {

            int horizontalPosition = CalculateHorizontal(positionInfo);
            int depthPosition = CalculateDepth(positionInfo);
            return depthPosition * horizontalPosition;
        }

        private static int CalculateDepth(List<KeyValuePair<string, int>> positionInfo)
        {
            int count = 0;
            foreach (var item in positionInfo)
            {
                if (item.Key.Trim() == "up")
                {
                    count -= item.Value;
                }
                if (item.Key.Trim() == "down")
                {
                    count += item.Value;
                }
            }
            return count;
        }

        private static int CalculateHorizontal(List<KeyValuePair<string, int>> positionInfo)
        {
            int count = 0;
            foreach (var item in positionInfo)
            {
                if (item.Key.Trim() == "forward")
                {
                    count += item.Value;
                }
            }
            return count;
        }

    }
}
