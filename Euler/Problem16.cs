using System;
using System.Linq;
using System.Numerics;

namespace euler
{
    // Power digit sum
    // https://projecteuler.net/problem=16
    public class Problem16
    {
        public static int GeneralizedSolution(int n)
        {
            return BigInteger.Pow(2, n).ToString().Select(v => int.Parse(new string(v, 1))).Sum();
        }
    }
}