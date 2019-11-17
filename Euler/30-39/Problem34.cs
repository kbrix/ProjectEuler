using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using euler.Utility;

namespace euler
{
    class Problem34
    {
        public static int Solution()
        {
            var numbers = new List<int>();

            for (int i = 10; i <= 40585; i++)
            {
                var digits = i.GetDigits();
                BigInteger sum = 0;
                foreach (var d in digits)
                {
                    sum += ((BigInteger) d).Factorial();
                }

                if (i == sum)
                {
                    numbers.Add(i);
                }
            }

            var result = numbers.Sum(); // 145, 40585
            return result;
        }
    }
}
