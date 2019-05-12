using System;
using System.Linq;

namespace euler
{
    public static class Problem5
    {
        public static bool IsEvenlyDivisibleBy(this int n, int m)
        {
            return n % m == 0;
        }

        public static int Solution()
        {
            var x = new bool[20];
            var n = 10;

            while (!x.All(y => y))
            {
                for (int i = 0; i < 20; i++)
                {
                    x[i] = n.IsEvenlyDivisibleBy(i+1);
                }

                n++;
            }
            
            return n-1;
        }
    }
}