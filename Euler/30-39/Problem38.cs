using System.Collections.Generic;
using System.Linq;
using euler.Utility;

namespace euler
{
    // Pandigital multiples
    static class Problem38
    {
        private static bool IsPandigital(this List<int> digits)
        {
            return !digits.Contains(0) && digits.Count == 9 && digits.Distinct().Count() == 9;
        }

        public static int Solution()
        {
            var max = 0;

            for (int i = 9000; i <= 10000; i++)
            {
                var digits = new List<int>();
                var j = 0;

                while (digits.Count < 9)
                {
                    j++;
                    var product = i * j;
                    digits.AddRange(product.GetDigits());
                }

                if (digits.IsPandigital())
                {
                    var number = digits.ConcatenateDigits();
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }

            return max;
        }
    }
}
