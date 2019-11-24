using System.Collections.Generic;
using System.Linq;
using euler.Utility;
using Microsoft.VisualBasic;

namespace euler
{
    // Truncatable primes
    public static class Problem37
    {
        private static bool IsTruncatablePrime(this int n)
        {
            var digits = n.GetDigits();
            for (int j = 0; j < digits.Count; j++)
            {
                var candidateLeftToRight = n.TruncateLeftToRight(j);
                if (!candidateLeftToRight.IsPrime())
                {
                    return false;
                }

                var candidateRightToLeft = n.TruncateRightToLeft(j);
                if (!candidateRightToLeft.IsPrime())
                {
                    return false;
                }
            }

            return true;
        }

        public static int Solution()
        {
            var truncatablePrimes = new List<int>();
            var max = 739397;

            for (int i = 11; i <= max; i += 2)
            {
                if (i.IsTruncatablePrime())
                {
                    truncatablePrimes.Add(i);
                }
            }
            
            // 23, 37, 53, 73, 313, 317, 373, 797, 3137, 3797, 739397
            return truncatablePrimes.Sum();
        }
    }
}
