using System.Text;

namespace Eight
{
    public static partial class SevenSegmentSearch
    {
        public static int CalculatePartOne()
        {
            List<string> signals = GetInput("input.txt");

            var count = signals
                .FindAll(sig => (sig.Length == 2) || (sig.Length == 3) || (sig.Length == 4) || (sig.Length == 7))
                .ToArray().Count();

            return count; //245
        }

        private static List<string> GetInput(string fileName)
        {
            var signals = new List<string>();

            File.ReadAllLines(fileName)
            .Select(line => line.Split("|").Last())
            .ToList()
            .Select(sl => sl.Trim().Split(" "))
            .ToList()
            .ForEach(i => i.ToList().ForEach(x => signals.Add(x)));
            return signals;
        }

        
        public static int CalculatePartTwo()
        {
            var listlines = File.ReadAllLines("input.txt")
                .Select(line => line.Trim().Split("|"))
                .ToList();

            var lineCountTotal = 0;
            foreach (var line in listlines)
            {
                var ruleList = line.First().Split(" ").ToList();
                Dictionary<string, string> mappingRuleDic = MapRule.GetRule(ruleList);

                var singalList = line.Last().Split(" ").ToList();
                var totalPerLine = GetValuePerLine(singalList, mappingRuleDic);
                lineCountTotal += totalPerLine;
            }

            return lineCountTotal;

            // 8394

        }

        private static int GetValuePerLine(List<string> line, Dictionary<string, string> mappingRuleDic)
        {
            var lineCode = new StringBuilder();
            foreach (var code in line)
            {
                if (mappingRuleDic.TryGetValue(code, out var number))
                {
                    lineCode.Append(number);
                }
            }
            return int.Parse(lineCode.ToString());
        }

    }
}

