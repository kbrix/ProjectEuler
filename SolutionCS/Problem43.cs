using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem43
    {
        // Sub-string divisibility (primes and pandigital numbers)

        private static readonly int[] Primes = { 2, 3, 5, 7, 11, 13, 17 };

        public static bool DivisibilityCondition(this long x)
        {
            var candidates = x.GetDigits().Skip(1).ToArray().Window(3);

            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].ConcatenateDigits() % Primes[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static long Solution()
        {
            var sum = 0L;
            var set = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var permutations = set.GetPermutations(set.Count);

            foreach (var permutation in permutations)
            {
                if (permutation.First() != 0)
                {
                    var candidate = permutation.Select(d => (long)d).ConcatenateDigits();
                    if (candidate.DivisibilityCondition())
                    {
                        sum += candidate;
                    }
                }
            }

            return sum;
        }
    }
}
