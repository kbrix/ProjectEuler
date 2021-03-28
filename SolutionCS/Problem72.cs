using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem72
    {
        public static BigInteger Solution(int n)
        {
            var sum = 1 + Enumerable.Range(1, n)
                .Select(PrimeUtility.EulerTotientFunction)
                .Select(x => new BigInteger(x))
                .Aggregate((a, b) => a + b);

            return sum - 2; // project euler does not count end-points
        }
    }
}
