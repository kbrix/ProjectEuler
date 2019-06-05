using System;
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
        
        
    }
}