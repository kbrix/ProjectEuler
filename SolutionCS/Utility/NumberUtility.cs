using System;
using System.Numerics;

namespace SolutionCS.Utility
{
    public static class NumberUtility
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

        public static long Reverse(long n)
        {
            var x = Reverse(n.ToString());
            return long.Parse(x);
        }

        public static BigInteger Reverse(BigInteger n)
        {
            var x = Reverse(n.ToString());
            return BigInteger.Parse(x);
        }

        public static bool IsPalindrome(this int n)
        {
            return n == Reverse(n);
        }

        public static bool IsPalindrome(this long n)
        {
            return n == Reverse(n);
        }

        public static bool IsPalindrome(this BigInteger n)
        {
            return n == Reverse(n);
        }
    }
}