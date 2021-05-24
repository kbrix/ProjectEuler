using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem104
    {
        public static int Solution()
        {
            BigInteger billion = 1_000_000_000; // has 9 zeros
            
            var a = new BigInteger(1);
            var b = new BigInteger(1);
            var c = new BigInteger(0);

            var stop = false;
            var counter = 2;
            
            while(!stop)
            {
                counter++;
                c = a + b;
                a = b;
                b = c;

                // get tail of number
                var tail = (long) (c % billion);
                
                if (!tail.IsPandigital()) continue;
                
                var numberOfDigits = 1 + (int) BigInteger.Log10(c);
                
                if (numberOfDigits <= 9) continue;
                
                // get head of number
                var head = (long) (c / BigInteger.Pow(10, numberOfDigits - 9));
                
                if (head.IsPandigital()) stop = true;
            }

            return counter;
        }
    }
}