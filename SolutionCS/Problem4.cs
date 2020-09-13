using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Largest palindrome product, https://projecteuler.net/problem=4
    public static class Problem4
    {
        public static int Solution()
        {
            var palindromes = new List<int>();

            for (int i = 100; i <= 999; i++)
            {
                for (int j = 100; j <= 999; j++)
                {
                    if (i <= j)
                    {
                        var x = i * j;
                        if (NumberUtility.IsPalindrome(x))
                        {
                            palindromes.Add(x);
                        }
                    }
                }
            }

            return palindromes.Max();
        }
    }
}