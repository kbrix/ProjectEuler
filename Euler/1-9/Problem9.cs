using System;
using System.Collections.Generic;
using System.Text;

namespace euler
{
    // Special Pythagorean triplet
    // See https://en.wikipedia.org/wiki/Pythagorean_triple#A_variant
    class Problem9
    {
        public static int Solution()
        {
            var a = 0;
            var b = 0;
            var c = 0;
            var m = 3;

            while (a + b + c != 1000)
            {
                for (int n = 1; n < m; n += 2)
                {
                    a = m * n;
                    b = (m * m - n * n) / 2;
                    c = (m * m + n * n) / 2;

                    if (a + b + c == 1000)
                    {
                        break;
                    }
                }
                
                m += 2;
            }

            return a * b * c;
        }
    }
}
