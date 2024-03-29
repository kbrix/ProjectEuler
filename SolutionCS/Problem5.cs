using System.Linq;

namespace SolutionCS
{
    public static class Problem5
    {
        public static bool IsEvenlyDivisibleBy(this int n, int m)
        {
            return n % m == 0;
        }

        public static int Solution()
        {
            var x = new bool[20];
            var n = 0;

            while (!x.All(y => y))
            {
                n += 20;

                for (int i = 0; i < 20; i++)
                {
                    x[i] = n.IsEvenlyDivisibleBy(i + 1);
                }
            }
            
            return n;
        }
    }
}