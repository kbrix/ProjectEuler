using System.Linq;

namespace SolutionCS
{
    public static class Problem76
    {
        private static readonly int[] Numbers = Enumerable.Range(1, 100).ToArray();

        public static int Solution()
        {
            return Problem31.Counter(100, Numbers) - 1;
        }
    }
}
