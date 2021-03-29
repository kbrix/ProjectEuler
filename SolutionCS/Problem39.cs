using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Integer right triangles
    // https://en.wikipedia.org/wiki/Pythagorean_triple#Generating_a_triple
    // Generate all triplets in sequence, compute sum, update counters, find largest counter
    public class Problem39
    {
        public static int Solution(int perimeter = 1000)
        {
            var counters = TripletCounter(perimeter).ToList();
            return counters.IndexOf(counters.Max());
        }

        public static IEnumerable<int> TripletCounter(int perimeter)
        {
            var counters = new int[perimeter + 1];
            var mMax = (int) Math.Sqrt(perimeter / 2d);

            for (int m = 2; m <= mMax; m++)
            {
                for (int n = 1; n < m; n++)
                {
                    if (IsTripletCondition(m, n))
                    {
                        var a = m * m - n * n;
                        var b = 2 * m * n;
                        var c = m * m + n * n;
                        
                        long p = a + b + c;

                        while (p <= perimeter)
                        {
                            counters[p] += 1;
                            p += a + b + c;
                        }
                    }
                }
            }

            return counters;
        }

        private static bool IsTripletCondition(int m, int n)
        {
            return (m - n) % 2 == 1 && // difference is odd
                   !(m % 2 == 1 && n % 2 == 1) && // both not odd
                   PrimeUtility.GreatestCommonDivisor(m, n) == 1; // co-prime
        }
    }
}
