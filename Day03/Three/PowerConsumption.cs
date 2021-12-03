namespace Three
{
    public static class PowerConsumption
    {
        public static decimal Calculate(string[] binStrings)
        {
            var binList = new List<char[]>();
            var resList = new List<char>();
            var epsilonList = new List<char>();   

            foreach (var line in binStrings)
            {
                char[] binaries = line.ToCharArray();
                binList.Add(binaries);
            }
            for (int i = 0; i < binList?.FirstOrDefault()?.Length; i++)
            {
                var oneCount = 0;
                var zeroCount = 0;
                foreach (var item in binList)
                {
                    if (item[i].Equals('1'))
                    {
                        oneCount++;
                    }
                    else if(item[i].Equals('0'))
                    {
                        zeroCount++; 
                    }
                }
                
                if (oneCount >= zeroCount) {
                    resList.Add('1');
                }
                else {
                    resList.Add('0');
                }

                if (oneCount <= zeroCount) {
                    epsilonList.Add('1');
                }
                else
                {
                    epsilonList.Add('0');
                }

            }

            
            var gammaBinaries = new string(resList.ToArray());
            
            var gammaInt = Convert.ToInt32(gammaBinaries,2);  

            var epsilonBinaries = new string(epsilonList.ToArray());
            var epsilonInt = Convert.ToInt32(epsilonBinaries, 2);

            return gammaInt * epsilonInt;
        }
    }
}
