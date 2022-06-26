using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionCS
{
    /// <summary>
    /// Odd period square roots. See <seealso href="https://projecteuler.net/problem=64"/>.
    /// </summary>
    public static class Problem64
    {
        private static bool IsPerfectSquare(int n)
        {
            return (int)Math.Sqrt(n) == Math.Sqrt(n);
        }

        /// <summary>
        /// Gets the periodic continued fraction expansion in canonical form for non-prefect squares.
        /// See the algorithm <seealso href="https://en.wikipedia.org/wiki/Periodic_continued_fraction"/>.
        /// </summary>
        /// <param name="s">A non-prefect square.</param>
        /// <returns>Periodic continued fraction expeansion.</returns>
        public static IEnumerable<int> GetPeriodicContinuedFractionSequence(int s)
        {
            if (IsPerfectSquare(s))
                throw new ArgumentOutOfRangeException(nameof(s), "Input cannot be a perfect square.");

            var m = 0;
            var d = 1;
            var a0 = (int)Math.Sqrt(s);
            var a = a0;

            var sequence = new List<int>();
            sequence.Add(a);

            do
            {
                m = d * a - m;
                d = (s - m * m) / d;
                a = (a0 + m) / d;
                sequence.Add(a);
            } while (
                a != 2 * a0
            );

            return sequence;
        }

        public static int Solution()
        {
            return Enumerable
                .Range(1, 10_000)
                .Where(n => !IsPerfectSquare(n))
                .Select(n =>
                {
                    var periodicContinuedFractionSequence = GetPeriodicContinuedFractionSequence(n).ToList();
                    var period = periodicContinuedFractionSequence.Count() - 1;
                    return period;
                })
                // Odd period
                .Count(p => p % 2 == 1);
        }
    }
}
