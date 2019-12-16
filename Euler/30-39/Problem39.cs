using System;
using System.Linq;
using euler.Utility;

namespace euler
{
    // Integer right triangles
    // https://en.wikipedia.org/wiki/Pythagorean_triple#Generating_a_triple
    // Generate all triplets in sequence, compute sum, update counters, find largest counter
    class Problem39
    {
        public static (double a, double b, double c) ass(int n, int a, int b)
        {
            return CommonFunctions.PythagoreanTriple(n, a, b);
        }

        public static int Solution()
        {
            var p = 1000;
            var counter = new int[p];

            var mMax = 150;
            var kMax = 15;

            for (int m = 2; m <= mMax; m++)
            {
                for (int n = 1; n < m; n++)
                {
                    for (int k = 1; k <= kMax; k++)
                    {
                        if (IsTripletCondition(m, n))
                        {
                            var a = k * (m * m - n * n);
                            var b = 2 * k * m * n;
                            var c = k * (m * m + n * n);
                            var sum = a + b + c;

                            if (sum <= p)
                            {
                                counter[sum - 1] += 1;
                            }
                        }
                    }
                }
            }

            var list = counter.ToList();
            return list.IndexOf(list.Max()) + 1;
        }

        private static bool IsTripletCondition(int m, int n)
        {
            return (m - n) % 2 == 1 && // difference is odd
                   PrimeUtility.GreatestCommonDivisor(m, n) == 1 && // co-prime
                   !(m % 2 == 1 && n % 2 == 1); // both not odd
        }
    }
}
