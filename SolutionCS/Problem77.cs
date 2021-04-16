using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem77
    {
        public static int Solution()
        {
            var i = 1;
            var count = 1;

            while (count <= 5000)
            {
                i++;
                var partitionOfPrimes = i.PrimeSieveOfEratosthenes().ToArray()[..^1];
                count = Problem31.Counter(i, partitionOfPrimes) - 1;
            }

            return i;
        }
    }
}
