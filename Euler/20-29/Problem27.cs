using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace euler
{
    class Problem27
    {
        private static int Polynomial(int n, int a, int b)
        {
            return n*n + a*n + b;
        }

        public static int PolynomialPrimeCounter(int a, int b)
        {
            var n = 0;
            var isPrime = true;

            while (isPrime && n <= 1000000)
            {
                isPrime = Polynomial(n, a, b).IsPrime();
                n++;
            }

            return n - 1;
        }

        public static int Solution()
        {
            var aa = new List<int>();
            var bb = new List<int>();
            var value = new List<int>();

            for (int a = -999; a <= 999; a++)
            {
                for (int b = 1; b <= 1000; b += 2)
                {
                    aa.Add(a);
                    bb.Add(b);
                    value.Add(PolynomialPrimeCounter(a, b));
                }
            }

            var max = value.Max();
            var index = value.IndexOf(max);

            return aa[index] * bb[index]; // a=-61, b=971, max=71
        }
    }
}
