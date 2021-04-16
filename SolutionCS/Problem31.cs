using System.Collections.Generic;

namespace SolutionCS
{
    public class Problem31
    {
        // Coin sums, https://projecteuler.net/problem=31
        // Use the recursive formula, https://www.algorithmist.com/index.php/Coin_Change

        public static int Counter(int n, IReadOnlyList<int> partitions)
        {
            return Counter(n, partitions.Count - 1, partitions, new Dictionary<(int, int), int>());
        }

        private static int Counter(int n, int m, IReadOnlyList<int> partitions, IDictionary<(int, int), int> cache)
        {
            if (n < 0 || m < 0)
                return 0;

            if (n == 0)
                return 1;

            if (cache.ContainsKey((n, m)))
                return cache[(n, m)];

            var result =
                Counter(n, m - 1, partitions, cache) +
                Counter(n - partitions[m], m, partitions, cache);

            cache.Add((n, m), result);

            return result;
        }

        private static readonly int[] PartitionOfCoins = { 1, 2, 5, 10, 20, 50, 100, 200 };

        public static int Solution(int change)
        {
            return Counter(change, PartitionOfCoins);
        }
    }
}
