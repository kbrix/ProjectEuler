using System;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem641
    {
        public static int SolutionForArbitraryNumberOfDice(int N)
        {
            var n1 = (decimal)Math.Pow(N, 1d / 6);
            var n2 = (decimal)Math.Pow(N, 1d / 4);
            
            return CalculateNumberOfDiceShowingOnes(n2, n1);
        }

        
        public static int Solution()
        {
            var n1 = 1000000; // 10^6
            var n2 = 1000000000; // 10^9
            
            return CalculateNumberOfDiceShowingOnes(n2, n1);
        }
        
        private static int CalculateNumberOfDiceShowingOnes(decimal n2, decimal n1)
        {
            var m = MobiusUtility.MobiusSieve((int) n2);

            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == -1)
                {
                    m[i] = 0;
                }
            }

            ArrayExtensions.MutableCumulativeSum(m);

            var index = Enumerable.Range(1, (int) n1).Select(a => n2 / (decimal) Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => (int) Math.Round(x, 6));

            var s = 0;

            foreach (var a in roundIndex)
            {
                s += m.ElementAt(a);
            }

            return s;
        }
    }
}