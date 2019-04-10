using System;
using System.Linq;

namespace euler
{
    public static class Problem6
    {
        public static int SumOfSquares(this int n)
        {
            return n * (n + 1) * (2*n + 1) / 6;
        }

        public static int SquareOfSum(this int n)
        {
            var m = Enumerable.Range(1, n).Sum();
            return m*m;
        }

        public static int Solution()
        {
            return SquareOfSum(100) - SumOfSquares(100);
        }
    }
}