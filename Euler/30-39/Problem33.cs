using System;
using euler.Utility;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    // Digit cancelling fractions
    public class Problem33
    {
        public static double Solution()
        {
            var tolerance = 0.0001;
            var numerator = new List<int>();
            var denominator = new List<int>();

            for (int i = 11; i <= 99; i++)
            {
                for (int j = i + 1; j <= 99; j++)
                {
                    var skipCondition = i % 10 == 0 | i % 11 == 0 | j % 10 == 0 | j % 11 == 0;
                    if (!skipCondition)
                    {
                        var x = i.GetDigits().ToHashSet();
                        var y = j.GetDigits().ToHashSet();
                        
                        // union - set difference - intersection
                        var digits = (x.Union(y)).Except(x.Intersect(y)).Select(z => (double)z).ToArray();

                        if (digits.Count() == 2 && Math.Abs((double)i / (double)j - digits[0] / digits[1]) < tolerance)
                        {
                            numerator.Add(i);
                            denominator.Add(j);
                        }
                    }
                }
            }

            // 16 19 26 49
            // 64 95 65 98
            return denominator.Product(x => x) / numerator.Product(x => x);
        }
    }
}