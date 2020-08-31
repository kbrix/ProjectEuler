using System.Collections.Generic;
using System.Linq;

namespace SolutionCS
{
    public static class Problem14
    {
        public static long CollatzValue(this long n)
        {
            return n % 2 == 0 ? n / 2 : 3 * n + 1;
        }

        public static int CollatzChain(this long n)
        {
            var counter = 2; 
            var value = CollatzValue(n);

            while (value != 1)
            {
                value = CollatzValue(value);
                counter++;
            }

            return counter;
        }

        public static int Solution()
        {
            var chainLength = new List<int>();
            for (int i = 0; i <= 1000000; i++)
            {
                chainLength.Add(CollatzChain(i + 1));
            }

            return 1 + chainLength.IndexOf(chainLength.Max());
        }
    }
}