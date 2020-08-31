using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Amicable numbers
    // https://projecteuler.net/problem=21
    public class Problem21
    {
        private static bool IsAmicableNumber(int n)
        {
            var sumOfProperDivisors = n.ProperDivisors().Sum();
            return sumOfProperDivisors != n && sumOfProperDivisors.Divisors().Sum() - sumOfProperDivisors == n;
        }
        
        public static int Solution()
        {
            var amicableNumbers = new List<int>();
            
            for (int n = 1; n < 10000; n++)
            {
                if (IsAmicableNumber(n))
                {
                    amicableNumbers.Add(n);
                }
            }
            return amicableNumbers.Sum();
        }
    }
}