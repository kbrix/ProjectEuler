using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem53
    {
        public static int Solution()
        {
            var counter = 0;

            for (BigInteger n = 1; n <= 100; n++)
            {
                for (BigInteger k = 1; k <= n; k++)
                {
                    var binomialCoefficient = CommonFunctions.BinomialCoefficient(n, k);
                    if (binomialCoefficient > 1_000_000)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
