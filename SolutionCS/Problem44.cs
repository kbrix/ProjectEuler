using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionCS
{
    public static class Problem44
    {
        // Pentagon numbers

        private static int PentagonNumber(int n) // n = 1, 2, 3, ...
        {
            return n * (3 * n - 1) / 2;
        }

        public static int Solution()
        {
            var n = 3000;

            var pentagonNumber = new Dictionary<int, int>();
            var sum = new Dictionary<(int, int), int>();
            var difference = new Dictionary<(int, int), int>();

            for (int i = 1; i <= n; i++)
            {
                pentagonNumber.Add(i, PentagonNumber(i));
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i < j)
                    {
                        var value = pentagonNumber[i] + pentagonNumber[j];
                        sum.Add((i, j), value);
                        sum.Add((j, i), value);
                    }

                    if (i == j)
                    {
                        sum.Add((i, j), pentagonNumber[i] + pentagonNumber[j]);
                    }

                    difference.Add((i, j), pentagonNumber[i] - pentagonNumber[j]);
                }
            }

            var maxPentagonNumber = sum.Max(x => x.Value);
            
            do
            {
                n++;
                pentagonNumber.Add(n, PentagonNumber(n));
            } while (pentagonNumber.Max(x => x.Value) <= maxPentagonNumber);

            var pentagonNumberSum = sum
                .Where(x => pentagonNumber.ContainsValue(x.Value))
                .ToDictionary(y => y.Key, y => y.Value);

            var pentagonNumberDifference = difference
                .Where(x => pentagonNumber.ContainsValue(x.Value))
                .ToDictionary(y => y.Key, y => y.Value);

            var pairs = pentagonNumberSum.Where(x => pentagonNumberDifference.ContainsKey(x.Key));
            
            var distances = new List<int>();

            foreach (var ((i, j), p) in pairs)
            {
                distances.Add(Math.Abs(pentagonNumber[i] - pentagonNumber[j]));
            }

            return distances.Min();
        }

    }
}
