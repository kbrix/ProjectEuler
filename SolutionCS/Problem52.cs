using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem52
    {
        public static bool ContainsSameDigits(BigInteger x, BigInteger y)
        {
            var d1 = x.GetDigits();
            var d2 = y.GetDigits();

            if (d1.Count != d2.Count)
                return false;

            if (d1.Distinct().Count() != d2.Distinct().Count())
                return false;

            var od1 = d1.OrderBy(a => a).ToArray();
            var od2 = d2.OrderBy(b => b).ToArray();
            
            for (int i = 0; i < od1.Length; i++)
            {
                if (od1[i] != od2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsSameDigits(BigInteger[] x)
        {
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (!ContainsSameDigits(x[i], x[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        public static BigInteger Solution(int n)
        {
            for (BigInteger i = 1; i <= n; i++)
            {
                var multiples = Enumerable.Range(1, 6).Select(y => y * i).ToArray();
                if (ContainsSameDigits(multiples))
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
