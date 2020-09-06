using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem49
    {
        public static long GetPrimePermutationSequence(this int n)
        {
            var indices = new List<int> { 0, 1, 2, 3 };
            var digits = n.GetDigits();
            var permutations = indices.GetPermutations(indices.Count);
            var numbers = new List<int>();

            foreach (var permutation in permutations)
            {
                var d1 = digits.ElementAt(permutation.ElementAt(0));
                var d2 = digits.ElementAt(permutation.ElementAt(1));
                var d3 = digits.ElementAt(permutation.ElementAt(2));
                var d4 = digits.ElementAt(permutation.ElementAt(3));
                if (d1 != 0)
                {
                    var number = new List<int> { d1, d2, d3, d4 };
                    numbers.Add(number.ConcatenateDigits());
                }
            }

            var primes = numbers.Distinct().Where(x => x.IsPrime());
            var triplets = Enumerable.Range(0, primes.Count()).GetPermutations(3);

            foreach (var triplet in triplets)
            {
                var p1 = primes.ElementAt(triplet.ElementAt(0));
                var p2 = primes.ElementAt(triplet.ElementAt(1));
                var p3 = primes.ElementAt(triplet.ElementAt(2));

                if (p2 - p1 == 3330 & p3 - p2 == 3330)
                {
                    string result = p1.ToString() + p2.ToString() + p3.ToString();
                    return long.Parse(result);
                }

            }

            return 0;
        }


        public static long Solution()
        {
            for (int i = 1000; i <= 9999; i++)
            {
                if (i.IsPrime())
                {
                    var result = i.GetPrimePermutationSequence();
                    if (result != 0 & result != 148748178147L)
                    {
                        return result;
                    }
                }

            }
            return 0;
        }
    }
}
