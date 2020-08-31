using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SolutionCS
{
    // Distinct powers, https://projecteuler.net/problem=29
    public class Problem29
    {
        public static int GeneralizedSolution(int a, int b)
        {
            var valueList = new List<BigInteger>();

            for (int i = 2; i <= a; i++)
            {
                for (int j = 2; j <= b; j++)
                {
                    valueList.Add(BigInteger.Pow(i, j));
                }
            }
            return valueList.Distinct().Count();
        }

        public static int Solution()
        {
            return GeneralizedSolution(100, 100);
        }
    }
}
