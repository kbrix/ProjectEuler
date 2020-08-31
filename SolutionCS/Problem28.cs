using System;

namespace SolutionCS
{
    // Number spiral diagonals
    public class Problem28
    {
        private static int NumberOfDiagonalElements(int n)
        {
            return 4 * n + 1;
        }

        public static int SpiralDiagonalSequence(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return n == 0 ? 1 : 2 * (1 + (int)Math.Floor((n - 1) / 4d)) + SpiralDiagonalSequence(n - 1);
        }

        public static int Solution(int n)
        {
            var sum = 0;

            var max = NumberOfDiagonalElements((int)Math.Floor(n / 2d));

            for (int i = 0; i < max; i++)
            {
                sum += SpiralDiagonalSequence(i);
            }

            return sum;
        }

        public static int Solution()
        {
            return Solution(1001);
        }
    }
}
