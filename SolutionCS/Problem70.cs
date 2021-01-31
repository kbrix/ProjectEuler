using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem70
    {
        public static int Solution(int max)
        {
            var results = new List<(int n, int phi, double ratio)>();

            for (int i = 2; i < max; i++)
            {
                int n = i;
                int phi = i.EulerTotientFunction();
                if (n.IsPermutationOf(phi))
                {
                    double ratio = n / (double) phi;
                    results.Add((n, phi, ratio));
                }
            }

            var minRatio = results
                .Select(x => x.ratio)
                .Min();

            var minValue = results
                .Where(x => x.ratio == minRatio)
                .Select(x => x.n)
                .Single();
            
            return minValue;
        }
    }
}
