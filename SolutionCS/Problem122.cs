using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SolutionCS
{
    // See also https://oeis.org/A003313
    public class Problem122
    {
        // Returns all the additive chains from '2' to 'maxElement'.
        // Minimal chains (not unique) must be filtered afterwards.
        // TODO only add minimal chains for extra performance.
        public static SortedDictionary<int, HashSet<int[]>> GetAdditiveChains(int maxElement)
        {
            var chainElements = Enumerable
                .Range(2, maxElement - 1)
                .ToArray();
            
            var start = new HashSet<int[]> {new[] {1, 2}};
            var justAddedChains = start;

            var cache = new SortedDictionary<int, HashSet<int[]>> {{2, start}};

            do
            {
                var newChains = new HashSet<int[]>();
                foreach (var chain in justAddedChains)
                {
                    var endElement = chain[^1];
                    foreach (var element in chain)
                    {
                        var newElement = element + endElement;
                        var newChain = chain.Concat(new[] {newElement}).ToArray();
                        if (newElement <= maxElement)
                        {
                            if (!cache.ContainsKey(newElement))
                            {
                                newChains.Add(newChain);
                                cache.Add(newElement, new HashSet<int[]>{newChain});
                            }
                            else
                            {
                                if (!cache[newElement].Contains(newChain))
                                {
                                    cache[newElement].Add(newChain);
                                    newChains.Add(newChain);
                                }
                            }
                        }
                    }
                }
                justAddedChains = newChains; 
            // TODO the while-clause here kills performance and should optimized
            } while (!cache.Keys.SequenceEqual(chainElements));
            return cache;
        }

        public static int Solution()
        {
            var chains = Problem122.GetAdditiveChains(200);
            
            var sum = 0;
            foreach (var c in chains)
            {
                sum += c.Value.Select(x => x.Length - 1).Min();
            }

            return sum;
        }
    }
}