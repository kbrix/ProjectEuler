using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    // Pandigital products
    public class Problem32
    {
        public static bool IsPandigital(int n1, int n2, int n3)
        {
            var digits1 = n1.GetDigits();
            var digits2 = n2.GetDigits();
            var digits3 = n3.GetDigits();

            if (digits1.Count() + digits2.Count() + digits3.Count != 9)
            {
                return false;
            }

            // returns the union of unique elements
            var union = digits1.Union(digits2.Union(digits3));

            if (union.Count() != 9)
                return false;

            if (union.Contains(0))
            {
                return false;
            }

            return true;
        }

        public static int Solution()
        {
            var triplets = new List<(int n1, int n2, int product)>();

            for (int i = 1; i <= 50; i++)
            {
                for (int j = 1; j <= 2000; j++)
                {
                    if (i <= j)
                    {
                        var product = i * j;
                        if (IsPandigital(i, j, product))
                        {
                            triplets.Add((i, j, product));
                        }
                    }
                }
            }

            var distinctProducts = triplets.Select(x => x.product).Distinct();
            return distinctProducts.Sum();
        }
    }
}
