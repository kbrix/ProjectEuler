using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    // Largest palindrome product, https://projecteuler.net/problem=4
    public static class Problem4
    {
        public static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            
            Array.Reverse(charArray);
            
            return new string(charArray);
        }

        public static int Reverse(int n)
        {
            var x = Reverse(n.ToString());
            
            return int.Parse(x);
        }

        public static bool IsPalindrome(int n)
        {
            return n == Reverse(n);
        }

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
                        if (IsPalindrome(x))
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