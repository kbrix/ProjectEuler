using System;

namespace SolutionCS.Utility
{
    public class MobiusUtility
    {
        public static int Mobius(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return -1;
            
            int p = 0;

            if (n % 2 == 0) // handle n=2 case separately
            {
                n = n / 2;
                p++;

                if (n % 2 == 0) return 0; // check if square-free integer
            }

            for (int i = 3; i <= Math.Sqrt(n); i = i+2)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    p++;

                    if (n % i == 0) return 0;
                }
            }

            return p % 2 == 0 ? -1 : 1; // check if number of distinct primes in the prime factorization is odd or even (function is multiplicative)
        }
        
        public static int[] MobiusSieve(int max)
        {
            var sqrt = (int)Math.Floor(Math.Sqrt(max));
            
            var mu = new int[max + 1];

            for (int i = 1; i <= max; i++)
            {
                mu[i] = 1;
            }
            
            for (int i = 2; i <= sqrt; i++)
            {
                if (mu[i] == 1)
                {
                    for (int j = i; j <= max; j += i)
                    {
                        mu[j] *= -i;
                    }

                    for (int j = i * i; j <= max && j > 1; j += i * i)
                    {
                        mu[j] = 0;
                    }
                }
            }
            
            for (int i = 2; i <= max; i++)
            {
                if (mu[i] == i)
                {
                    mu[i] = 1;
                }
                else if (mu[i] == -i)
                {
                    mu[i] = -1;
                }
                else if (mu[i] < 0)
                {
                    mu[i] = 1;
                }
                else if (mu[i] > 0)
                {
                    mu[i] = -1;
                }
            }
            
            return mu;
        }
    }
}