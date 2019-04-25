using System.Linq;

namespace euler
{
    public class Problem10
    {
        public static long GeneralizedSolution(int n)
        {
            var primes = PrimeUtility.PrimeSieveOfEratosthenes(n);
            
            long sum = primes.Select(x => (long) x).Sum();
            
            return sum;
        }
        
       
        public static long Solution()
        {
            return GeneralizedSolution(2000000);
        }
    }
}