using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace euler
{
    public class PrimeUtility
    {
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

        public static long poo(long n)
        {
            var largestPrimeFactor = new long();
            var multipleOfSix = new long();
            
            if (n % 2 == 0)
            {
                largestPrimeFactor = 2;
                while (n % 2 == 0)
                {
                    n = n / 2;
                }
            }
            
            if (n % 3 == 0)
            {
                largestPrimeFactor = 3;
                while (n % 3 == 0)
                {
                    n = n / 3;
                }
            }

            multipleOfSix = 6;
            while (multipleOfSix - 1 <= n)
            {
                if (n % (multipleOfSix - 1) == 0)
                {
                    largestPrimeFactor = multipleOfSix - 1;
                    while (n % largestPrimeFactor == 0)
                    {
                        n = n / largestPrimeFactor;
                    }
                }

                if (n % (multipleOfSix + 1) == 0)
                {
                    largestPrimeFactor = multipleOfSix + 1;
                    while (n % largestPrimeFactor == 0)
                    {
                        n = n / largestPrimeFactor;
                    }
                }

                multipleOfSix += 6;
            }

            return multipleOfSix;
        }
        
        public static long kook(long n)
        {
            long i = 6;

            while (n > 1)
            {
                while (n % 2 == 0) // consider 2
                {
                    n = n / 2;
                }
                
                while (n % 3 == 0) // consider 3
                {
                    n = n / 3;
                }
                
                // Now all primes are og the form 6*i+1 or 6*i-1
                
                while (n % (i-1) == 0)
                {
                    n = n / (i-1);
                }
                
                while (n % (i+1) == 0)
                {
                    n = n / (i+1);
                }

                i = i + 6;

                if (i*i > n && n > 1)
                {
                    return n;
                }
            }

            return i - 1;
        }
        
        
        public static long kook2(long n)
        {
            long i = 0;

            while (n > 1)
            {
                while (n % 2 == 0) // consider 2
                {
                    n = n / 2;
                }
                
                while (n % 3 == 0) // consider 3
                {
                    n = n / 3;
                }
                
                while (n % 5 == 0) // consider 5
                {
                    n = n / 5;
                }
                
                // Now all primes are og the form 30*i+k, where i>=0, k=7,11,13,17,19,23,29
                
                while (n % (i+7) == 0)
                {
                    n = n / (i+7);
                }
                
                while (n % (i+11) == 0)
                {
                    n = n / (i+11);
                }
                
                while (n % (i+13) == 0)
                {
                    n = n / (i+13);
                }
                
                while (n % (i+17) == 0)
                {
                    n = n / (i+17);
                }
                
                while (n % (i+19) == 0)
                {
                    n = n / (i+19);
                }
                
                while (n % (i+23) == 0)
                {
                    n = n / (i+23);
                }
                
                while (n % (i+29) == 0)
                {
                    n = n / (i+29);
                }

                i = i + 30;

                if (i*i > n && n > 1)
                {
                    return n;
                }
            }

            return i - 1;
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
        
    }
}