using System;
using System.Collections.Generic;
using System.Text;

namespace euler.Utility
{
    static class ArrayExtensions
    {
        public static long Product(this IEnumerable<int> a)
        {
            long product = 1;
            foreach (var x in a)
            {
                product *= x;
            }
            return product;
        }
    }
}
