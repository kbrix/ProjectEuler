using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem62
    {
        public static BigInteger Solution(int m)
        {
            // For each cube, check if cube is a permutation of a previous cube, remember count and cubes, stop when counter is 'n'.
            var cache = new Dictionary<BigInteger, (List<BigInteger>, int)>(); // largest cube permutation, (cubes, counter)
            var n = (BigInteger) 0;
            var continueSearch = true;

            List<BigInteger> cubes = new List<BigInteger>();
            int counter;

            while (continueSearch)
            {
                n++;
                var cube = n * n * n;
                var permutation = cube.Digits().OrderByDescending(x => x).ConcatenateDigits();
                
                if (!cache.ContainsKey(permutation))
                {
                    cache.Add(permutation, (new List<BigInteger> { cube }, 1));
                }
                else
                {
                    (cubes, counter) = cache[permutation];

                    cubes.Add(cube);
                    counter++;

                    cache.Remove(permutation);
                    cache.Add(permutation, (cubes, counter));

                    if (counter == m)
                    {
                        continueSearch = false;
                    }
                }
            }

            (cubes, _) = cache.Single(x => x.Value.Item2 == m).Value; // where-clause on 'counter'
            return cubes.OrderBy(x => x).First(); 
        }

        // Comment on bug in code!
        // Brian  Northern Ireland
        // Wed, 21 Sep 2005, 16:08
        // ke9tv, you have the same bug I initially had.The first N permutations you find don't necessarily
        // correspond to the smallest cube, as you may find a higher cube that is a permutation of a smaller
        // initial cube. It is also possible that the one you stop at actually has more than N permutations,
        // thus violating the <em>exactly</em> N permutations condition.
        // Fortunately, for 5 permutations, this doesn't happen, but for N=6, you will get 1426487591593,
        // but 1000600120008 is lower, and also has 6 cube permutations.
        // (This is easy enough to fix - continue until you have reached an extra digit, and you can
        // guarantee that no further permutations will be found for the earlier cubes)
    }
}
