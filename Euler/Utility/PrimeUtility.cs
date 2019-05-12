using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using euler.Utility;

namespace euler
{
    public static class PrimeUtility
    {
        public static List<int> PrimeSieveOfEratosthenes(this long n) 
        {
            bool[] isPrime = new bool[n+1];

            for (int i = 0; i <= n; i++)
            {
                isPrime[i] = true;
            } 
          
            for(int p = 2; p * p <= n; p++) 
            {
                if(isPrime[p]) 
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    } 
                } 
            } 
            
            var primes = new List<int>();
            for(int i = 2; i <= n; i++) 
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                } 
            }

            return primes;
        } 
          
        
        public static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            var remainder = new BigInteger();
            
            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }
        
        public static long LargestPrimeFactor(long n)
        {
            long i = 2;

            while (n > 1)
            {
                while (n % i == 0)
                {
                    n = n / i;
                }

                i++;

                if (i*i > n && n > 1)
                {
                    return n;
                }
            }

            return i - 1;
        }
        
        public static long LargestPrimeFactorUsingSieve(long n, IEnumerable<int> primes)
        {
            int x = new int();

            foreach (var p in primes)
            {
                while (n % p == 0)
                {
                    x = p;
                    n = n / x;
                }
            }
            
            return (n > 1) ? n : x;
        }

        public static IEnumerable<int> Factorize(this int n)
        {
            var factors = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }
        
        public static int FactorCounter(this int n)
        {
            var count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int DivisorFunction(this int n)
        {
            var max = (int)Math.Sqrt(n) + 1;
            var powers = new List<int>();
            
            for (int i = 2; i < max; i++)
            {
                while (n > 1)
                {
                    var counter = 0;
                    
                    while (n % i == 0)
                    {
                        n = n / i;
                        counter++;
                    }
                    
                    powers.Add(counter);

                    i++;
                }
            }
            return powers.Product(x => x + 1);
        }
    }
}