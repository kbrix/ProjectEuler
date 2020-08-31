using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem23
    {
        private static bool IsAbundantNumber(int n)
        {
            return n.ProperDivisors().Sum() > n;
        }

        public static int Solution()
        {
            var max = 28123;
            var abundantNumbers = new List<int>();
            
            for (int i = 12; i <= max; i++)
            {
                if (IsAbundantNumber(i))
                {
                    abundantNumbers.Add(i);
                }
            }
            
            var sumOfTwoAbundantNumbers = new List<int>();

            foreach (var x in abundantNumbers)
            {
                foreach (var y in abundantNumbers)
                {
                    if (x <= y)
                    {
                        var z = x + y;
                        if (z <= max)
                        {
                            sumOfTwoAbundantNumbers.Add(z);
                        }
                    }
                }
            }

            var a = Enumerable.Range(1, max).ToHashSet();
            var b = a.Except(sumOfTwoAbundantNumbers);

            return b.Sum();
        }
    }
}