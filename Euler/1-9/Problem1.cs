using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    public static class Problem1
    {
        public static bool IsMultiplesOfInteger(int x, int n)
        {
            if (x <= 0)
            {
                throw new ArgumentOutOfRangeException("The 'x' value must be a natural number");
            }
            
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("The 'n' value must be a natural number");
            }
            
            return x % n == 0;
        }

        public static int Solution(int N)
        {
            var multiples = new List<int>();
            
            for (int i = 1; i < N; i++)
            {
                if (IsMultiplesOfInteger(i, 3) || IsMultiplesOfInteger(i, 5))
                {
                    multiples.Add(i);
                }
            }

            return multiples.Sum();
        }
    }
}