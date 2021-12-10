using System.Text;

namespace Ten
{
    public static class SyntaxErrorScore
    {
        private static string _fileName = "input.txt";
        private static Dictionary<char, char> _pairs = new Dictionary<char, char> {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' },
        };

        public static long GetIncompleteLinesScore()
        {
            var lines = File.ReadAllLines(_fileName);

            var corruptedLines = GetsyntaxError().Item2.ToArray();

            var incompleteLines = lines.Except(corruptedLines).ToArray();

            List<long> totalScoreLines = new(); 

            foreach (var line in incompleteLines)
            {
                var incompletePart = GetCompleteByList(line);
                if (!string.IsNullOrEmpty(incompletePart))
                {
                    string completingPart = GetCompletingPart(incompletePart);
                    var scoreCompltingPart = GetScoreCompltingPart(completingPart);
                    totalScoreLines.Add(scoreCompltingPart);
                }
            }

            totalScoreLines.Sort();
            var middleScore = totalScoreLines[totalScoreLines.Count / 2];

            return middleScore;
        }

        private static long GetScoreCompltingPart(string completingPart)
        {
            long total = 0;
            foreach (var item in completingPart)
            {

                total = (total * 5) + GetAutoCompletePoint(item);
            }
            return total;
        }

        private static string GetCompletingPart(string incompletePart)
        {
            if (incompletePart.Length == 0)
                return "";
            var completingPart = new StringBuilder();
            foreach (var ch in incompletePart)
            {
                var test = _pairs[ch];
                completingPart.Append(test);

            }
            return completingPart.ToString();
        }

        public static int GetSumsytaxtErrorScore()
        {
            List<int> scores = GetsyntaxError().Item1;

            return scores.Sum();
        }

        public static Tuple<List<int>, List<string>> GetsyntaxError()
        {
            List<int> scores = new();

            List<string> illegalLines = new();
            var lines = File.ReadAllLines(_fileName);

            foreach (var line in lines)
            {
                var pairedResult = IsPaired(line);
                if (!pairedResult.Item1)
                {
                    int point = GetErrorPoint(pairedResult.Item2);
                    scores.Add(point);
                    illegalLines.Add(line);
                }
            }

            return Tuple.Create(scores, illegalLines);
        }

        private static int GetErrorPoint(char input)
        {
            switch (input)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;

            }
            return 0;
        }

        public static Tuple<bool, char> IsPaired(string input)
        {

            Stack<char> brackets = new Stack<char>();

            foreach (var item in input)
            {
                if (_pairs.ContainsKey(item))
                {
                    brackets.Push(item);
                }
                else if (_pairs.Values.Contains(item))
                {
                    if (brackets.Count == 0) return Tuple.Create(false, item);

                    var openingBracket = brackets.Pop();
                    if (_pairs[openingBracket] != item) return Tuple.Create(false, item);

                }
            }

            return Tuple.Create(true, new char());
        }

        private static int GetAutoCompletePoint(char input)
        {
            switch (input)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;

            }
            return 0;
        }

        public static string GetCompleteByList(string input)
        {
            Stack<char> brackets = new Stack<char>();

            foreach (var item in input)
            {
                if (_pairs.ContainsKey(item))
                {
                    brackets.Push(item);
                }
                else if (_pairs.Values.Contains(item))
                {
                    brackets.Pop();
                }
            }
            var result = new StringBuilder();
            foreach (var item in brackets)
            {
                result.Append(item);
            }



            return result.ToString();
        }
    }
}
