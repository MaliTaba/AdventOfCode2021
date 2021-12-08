using static Eight.SevenSegmentSearch;

namespace Eight
{
    public static class MapRule
    {
        public static Dictionary<string, string> GetRule(List<string> ruleList)
        {
            var mappingRule = new Dictionary<string, string>(new EquilityComparer()) { };

            foreach (var rule in ruleList)
            {
                // Get mapping rule based on the size
                switch (rule.Length)
                {
                    case 2:
                        mappingRule[rule] = "1";
                        break;
                    case 3:
                        mappingRule[rule] = "7";
                        break;
                    case 4:
                        mappingRule[rule] = "4";
                        break;
                    case 7:
                        mappingRule[rule] = "8";
                        break;

                    default:
                        break;
                }
            }

            var codeSeven = mappingRule.FindFirstKeyByValue("7");
            var codeOne = mappingRule.FindFirstKeyByValue("1");
            var codeFour = mappingRule.FindFirstKeyByValue("4");
            var codeEight = mappingRule.FindFirstKeyByValue("8");

            var listOptions = new string[7];
            var diffOneSeven = codeSeven.Except(codeOne).First().ToString();
            listOptions[0] = diffOneSeven;
            listOptions[1] = codeOne;
            listOptions[2] = codeOne;

            var diffEightAll = codeEight.Except(codeFour).ToArray();
            var eiDiff = string.Join("", diffEightAll);
            listOptions[3] = string.Join("", eiDiff.Except(codeSeven).ToArray());
            listOptions[4] = string.Join("", eiDiff.Except(codeSeven).ToArray());
            listOptions[5] = string.Join("", codeFour.Except(codeOne).ToArray());
            listOptions[6] = string.Join("", codeFour.Except(codeOne).ToArray());

            var codePresentTwo = CodePresentTwo(ruleList, listOptions[2], listOptions[6], 5);
            mappingRule[codePresentTwo] = "2";

            var codePresentThree = CodePresentTwo(ruleList, listOptions[4], listOptions[6], 5);
            mappingRule[codePresentThree] = "3";

            var codePresentze = CodePresentTwo(ruleList, listOptions[5], "", 6);
            mappingRule[codePresentze] = "0";

            var codePresentFive = CodePresentTwo(ruleList, listOptions[1], listOptions[4], 5);
            mappingRule[codePresentFive] = "5";

            var codePresentSix = CodePresentTwo(ruleList, listOptions[1], "", 6);
            mappingRule[codePresentSix] = "6";

            var codePresentNine = CodePresentTwo(ruleList, listOptions[4], "", 6);
            mappingRule[codePresentNine] = "9";

            return mappingRule;

        }

        public static string CodePresentTwo(List<string> ruleList, string unwantedOne, string unwantedTwo, int len)
        {
            //Change method name to be generic
            var TwoRule = "";
            var unwantedChars = new string[] { unwantedOne, unwantedTwo };
            foreach (var code in ruleList)
            {
                if (code.Length != len) // length manually calculated
                {
                    continue;
                }
                else
                {
                    if (code.Contains(unwantedChars[0].ToArray().First()) && code.Contains(unwantedChars[0].ToArray().Last()))
                    {
                        continue;
                    }

                    if (unwantedTwo.Length > 0)
                    {

                        if (code.Contains(unwantedChars[1].ToArray().First()) && code.Contains(unwantedChars[1].ToArray().Last()))
                        {
                            continue;
                        }
                    }

                    return code;
                }
            }
            return TwoRule;
        }

        public static K FindFirstKeyByValue<K, V>(this Dictionary<K, V> dict, V val)
        {
            return dict.FirstOrDefault(entry =>
                EqualityComparer<V>.Default.Equals(entry.Value, val)).Key;
        }

    }
}
