using System.Collections.Generic;
using System.Linq;
using euler.Utility;

namespace euler
{
    class Problem40
    {
        // Champernowne's constant
        public static int Solution()
        {
            var digits = new List<int>();

            for (int i = 1; i <= 200000; i++)
            {
                digits.AddRange(i.GetDigits());
            }

            var d1       = digits.ElementAt(1 - 1);
            var d10      = digits.ElementAt(10 - 1);
            var d100     = digits.ElementAt(100 - 1);
            var d1000    = digits.ElementAt(1000 - 1);
            var d10000   = digits.ElementAt(10000 - 1);
            var d100000  = digits.ElementAt(100000 - 1);
            var d1000000 = digits.ElementAt(1000000 - 1);
            
            return d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000;
        }
    }
}
