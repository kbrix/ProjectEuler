using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler.Utility
{
    public static class CommonFunctions
    {
        public static BigInteger Factorial(this BigInteger x)
        {
            if (x < 0)
            {
                throw new ArgumentException("The input for the Factorial function must be a non-negative integer!");
            }
            
            return (x == 0 || x == 1) ? 1 : x * (x - 1).Factorial();
        }
        
        public static BigInteger BinomialCoefficient(BigInteger n, BigInteger k)
        {
            return !(n >= k && k >= 0) ? 0 : n.Factorial() / (k.Factorial() * (n - k).Factorial());
        }

        public static List<int> GetDigits(this int number, int baseNumber = 10)
        {
            var digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % baseNumber);
                number /= baseNumber;
            }
            return digits;
        }

        public static List<BigInteger> GetDigits<T>(this BigInteger number, int baseNumber = 10)
        {
            var digits = new List<BigInteger>();
            while (number > 0)
            {
                digits.Add(number % baseNumber);
                number /= baseNumber;
            }
            digits.Reverse();
            return digits;
        }

    }
}