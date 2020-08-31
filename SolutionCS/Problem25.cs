using System.Collections.Generic;
using System.Numerics;

namespace SolutionCS
{
    // 1000-digit Fibonacci number, https://projecteuler.net/problem=25
    public class Problem25
    {
        public static int GeneralizedSolution(int n)
        {
            var values = new List<BigInteger> { 1, 1 };
            var check = true;
            var i = 2;

            while (check)
            {
                values.Add(values[i - 2] + values[i - 1]);
                check = values[i] <= BigInteger.Pow(10, n);
                i++;
            }

            return i;
        }

        public static int Solution()
        {
            return GeneralizedSolution(999);
        }
    }
}
