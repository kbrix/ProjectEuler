using System.Collections.Generic;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Circular primes
    public static class Problem35
    {
        public static bool IsCircularPrime(this int n)
        {
            if (n == 2)
            {
                return true;
            }

            if (!n.IsPrime())
            {
                return false;
            }

            var digits = n.GetDigits();

            for (int i = 0; i <= 8; i += 2)
            {
                if (digits.Contains(i))
                {
                    return false;
                }
            }

            var digitCount = digits.Count;

            for (int i = 1; i < digitCount; i++)
            {
                if (!digits.Rotate(i).ConcatenateDigits().IsPrime())
                {
                    return false;
                }
            }

            return true;
        }

        public static int Solution()
        {
            //var n = 100;
            var n = 1000000;
            var counter = 0;
            var circularPrimes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (i.IsCircularPrime())
                {
                    counter++;
                    circularPrimes.Add(i);
                }
            }

            return counter;
        }
    }
}
