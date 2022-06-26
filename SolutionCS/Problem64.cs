using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    /// <summary>
    /// Odd period square roots. See <see href="https://projecteuler.net/problem=64"/>.
    /// </summary>
    public static class Problem64
    {
        public static int Solution()
        {
            return Enumerable
                .Range(1, 10_000)
                .Where(n => !Miscellaneous.IsPerfectSquare(n))
                .Select(n =>
                {
                    var periodicContinuedFractionSequence = Miscellaneous
                        .GetPeriodicContinuedFractionSequence(n)
                        .ToList();
                    var period = periodicContinuedFractionSequence.Count() - 1;
                    return period;
                })
                // Odd period
                .Count(p => p % 2 == 1);
        }
    }
}
