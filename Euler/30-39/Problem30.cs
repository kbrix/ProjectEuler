using System;
using euler.Utility;

namespace euler
{
    class Problem30
    {
        public static int Solution(int p)
        {
            var min = 2 * Math.Pow(2, p);
            var max = p * Math.Pow(9, p);

            var sum = 0;

            for (var i = (int)min; i <= (int)max; i++)
            {
                var y = (int) Math.Pow(i.DigitSum(), 5);

                if (i == y)
                {
                    sum += y;
                }
            }

            return sum;
        }
    }
}
