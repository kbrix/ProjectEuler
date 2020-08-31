using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem7
    {      
        public static long Solution()
        {
            // see links:
            // https://en.wikipedia.org/wiki/Prime_number_theorem#Approximations_for_the_nth_prime_number
            // https://math.stackexchange.com/questions/1270814/bounds-for-n-th-prime
            
            const long n = 10001;
            const int N = 114319; // n*(log(n) + log(log(n)))
            
            var primes = PrimeUtility.PrimeSieveOfEratosthenes(N);
            return primes[(int)(n-1)];
        }
    }
}