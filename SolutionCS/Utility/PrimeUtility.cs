using System;
using System.Collections.Generic;
using System.Numerics;

namespace SolutionCS.Utility
{
    public static class PrimeUtility
    {
        public static bool IsPrime(this int x)
        {
            if (x <= 1)
                return false;
            
            if (x == 2)
                return true;

            if (x % 2 == 0)
                return false;

            for (int i = 3; i*i <= x; i += 2)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

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

        public static List<int> PrimeSieveOfEratosthenes(this int n)
        {
            bool[] isPrime = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            var primes = new List<int>();
            for (int i = 2; i <= n; i++)
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
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                var remainder = a % b;
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

        public static IEnumerable<int> PrimeFactors(this int n)
        {
            var primeFactors = new List<int>();

            var sieve30 = new[] {7, 11, 13, 17, 19, 23, 29, 31};
            var initialPrimes = new List<int>(new [] {2, 3, 5});
            var wheelFactor = 30;

            foreach (var p in initialPrimes)
            {
                while (n % p == 0)
                {
                    n /= p;
                    primeFactors.Add(p);
                }
            }

            var max = (int) Math.Sqrt(n);

            for (int i = 0; i <= max; i += wheelFactor)
            {
                foreach (var sieve in sieve30)
                {
                    var m = i + sieve;
                    while (n % m == 0)
                    {
                        n /= m;
                        primeFactors.Add(m);
                    }
                }
            }

            if (n != 1)
            {
                primeFactors.Add(n);
            }

            return primeFactors;
        }

        public static IEnumerable<long> PrimeFactors(this long n)
        {
            var primeFactors = new List<long>();

            var sieve30 = new long[] { 7, 11, 13, 17, 19, 23, 29, 31 };
            var initialPrimes = new List<int>(new[] { 2, 3, 5 });
            var wheelFactor = 30;

            foreach (var p in initialPrimes)
            {
                while (n % p == 0)
                {
                    n /= p;
                    primeFactors.Add(p);
                }
            }

            var max = (int)Math.Sqrt(n);

            for (long i = 0; i <= max; i += wheelFactor)
            {
                foreach (var sieve in sieve30)
                {
                    var m = i + sieve;
                    while (n % m == 0)
                    {
                        n /= m;
                        primeFactors.Add(m);
                    }
                }
            }

            if (n != 1)
            {
                primeFactors.Add(n);
            }

            return primeFactors;
        }

        /// <summary>
        /// Returns factors/divisors of a number
        /// </summary>
        public static IEnumerable<int> Divisors(this int n)
        {
            var divisors = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }
        
        /// <summary>
        /// Returns proper factors/divisors of a number
        /// </summary>
        public static IEnumerable<int> ProperDivisors(this int n)
        {
            var properDivisors = new List<int>();

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    properDivisors.Add(i);
                }
            }
            return properDivisors;
        }
        
        /// <summary>
        /// Returns number of factors/divisors of a number
        /// </summary>
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

        public static List<int> DivisorFunction(this int n)
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
            return powers;
        }
        
        public static int GetNumberOfDivisors(this int n)
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