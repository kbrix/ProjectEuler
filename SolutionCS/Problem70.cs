using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem70
    {

        public static int Solution(int max)
        {
            var source = Enumerable.Range(2, max);

            var results = source
                .AsParallel()
                .Select(n =>
                {
                    int phi = n.EulerTotientFunction();
                    double ratio = n / (double) phi;
                    return (n, phi, ratio);
                })
                .Where(x => x.n.IsPermutationOf(x.phi))
                .ToList();

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
