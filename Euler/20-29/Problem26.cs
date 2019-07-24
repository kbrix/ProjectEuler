using System;
using System.Collections.Generic;
using System.Text;

namespace euler
{
    // Reciprocal cycles
    class Problem26
    {
        public static int RepeatingDigitCount(int n)
        {
            var digits = new HashSet<int>();
            var x = 1 % n;

            while (!digits.Contains(x))
            {
                digits.Add(x);
                x = (10 * x) % n;
            }

            return digits.Count;
        }

        public static int Solution(int n)
        {
            var max = 0;
            var maxIndex  = 0;

            for (int i = 1; i < n; i++)
            {
                var numberOfDigits = RepeatingDigitCount(i);

                if (numberOfDigits > max)
                {
                    max = numberOfDigits;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
