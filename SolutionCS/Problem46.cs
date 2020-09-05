using System;
using System.Collections.Generic;
using System.Text;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem46
    {
        public static bool IsSumOfPrimeAndTwiceSquare(int n)
        {
            var primes = PrimeUtility.PrimeSieveOfEratosthenes(n);

            foreach (var prime in primes)
            {
                for (int i = 1; i <= n; i++)
                {
                    var condition = prime + 2 * i * i == n;
                    if (condition)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static int Solution(int max)
        {
            var primes = PrimeUtility.PrimeSieveOfEratosthenes(max).ToArray();

            for (int i = 9; i <= max; i += 2)
            {
                if (!i.IsPrime())
                {
                    if (!IsSumOfPrimeAndTwiceSquare(i))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
