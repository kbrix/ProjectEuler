using System.Collections.Generic;
using System.Linq;

namespace euler
{
    // Amicable numbers
    // https://projecteuler.net/problem=21
    public class Problem21
    {
        private static bool IsAmicableNumber(int n)
        {
            var sumOfProperDivisors = n.Factorize().Sum() - n;
            return sumOfProperDivisors != n && sumOfProperDivisors.Factorize().Sum() - sumOfProperDivisors == n;
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