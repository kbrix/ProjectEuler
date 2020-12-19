using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class ConcatenatedPrimeCollection
    {
        public List<int> Collection { get; set; }
    }

    public class ConcatenatedPrimeCollectionComparer : IEqualityComparer<ConcatenatedPrimeCollection>
    {
        public bool Equals([NotNull] ConcatenatedPrimeCollection x, [NotNull] ConcatenatedPrimeCollection y)
        {
            if (x.Collection.Count != y.Collection.Count) return false;

            x.Collection.Sort();
            y.Collection.Sort();

            for (int i = 0; i < x.Collection.Count; i++)
            {
                if (x.Collection.ElementAt(i) != y.Collection.ElementAt(i)) 
                    return false;
            }

            return true;
        }

        public int GetHashCode(ConcatenatedPrimeCollection x)
        {
            return x.Collection.Aggregate((a, b) => a.GetHashCode() ^ b.GetHashCode());
        }
    }

    public static class Problem60
    {
        public static int Solution(int n, int m)
        {
            if (n <= 1)
                throw new ArgumentException();

            var candidates = new List<ConcatenatedPrimeCollection>();
            var primes = m.PrimeSieveOfEratosthenes();
            var primeCombinations = primes.GetCombinations(2);

            foreach (var primeCombination in primeCombinations)
            {
                if (IsConcatenatedPrimePair(primeCombination.ElementAt(0), primeCombination.ElementAt(1)))
                    candidates.Add(new ConcatenatedPrimeCollection { Collection = primeCombination.ToList() });
            }

            var counter = 3;
            while (n >= 3 && counter != n)
            {
                foreach (var prime in primes)
                {
                    foreach (var candidate in candidates)
                    {
                        if (candidate.Collection.All(p => IsConcatenatedPrimePair(p, prime)))
                        {
                            candidate.Collection.Add(prime);
                            candidate.Collection.Sort();
                        }
                    }
                }

                candidates.RemoveAll(candidate => candidate.Collection.Count != n);
                candidates = candidates.Distinct(new ConcatenatedPrimeCollectionComparer()).ToList();
                counter++;
            }

            return candidates.Select(x => x.Collection.Sum()).Min();
        }

        private static readonly Dictionary<int, bool> Cache = new Dictionary<int, bool>();

        public static bool IsConcatenatedPrimePair(int x, int y)
        {
            var xs = x.ToString();
            var ys = y.ToString();
            var a = int.Parse(xs + ys);
            var b = int.Parse(ys + xs);

            if (!Cache.ContainsKey(a))
                Cache.Add(a, a.IsPrime());
            
            if (!Cache.ContainsKey(b))
                Cache.Add(b, b.IsPrime());

            return Cache[a] && Cache[b];
        }
    }
}
