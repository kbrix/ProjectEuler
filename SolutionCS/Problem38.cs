using System.Collections.Generic;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Pandigital multiples
    public static class Problem38
    {
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
