using System;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Double-base palindromes
    public class Problem36
    {
        public static bool IsPalindrome(string n)
        {
            return n == NumberUtility.Reverse(n);
        }

        private static bool IsDualPalindrome(int n)
        {
            if (!NumberUtility.IsPalindrome(n))
            {
                return false;
            }

            var base2 = Convert.ToString(n, 2);

            if (!IsPalindrome(base2))
            {
                return false;
            }

            return true;
        }

        public static int Solution()
        {
            var sum = 0;

            for (int i = 1; i < 1000000; i++)
            {
                if (IsDualPalindrome(i))
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
