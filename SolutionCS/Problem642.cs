using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem642
    {
        public static long SolutionForArbitraryInput(long n)
        {
            var summand = ReturnLargestPrimeFactors(n);
            return summand.Sum();
        }
        
        public static long Solution()
        {
            long n = 201820182018;

            var summand = ReturnLargestPrimeFactors(n);
            return summand.Sum() % 1000000000;
        }
        
        private static List<long> ReturnLargestPrimeFactors(long n)
        {
            var summand = new List<long>();

            for (long i = 2; i <= n; i++)
            {
                summand.Add(PrimeUtility.LargestPrimeFactor(i));
            }

            return summand;
        }
        
        public static long SolutionForArbitraryInputUsingSieve(long n)
        {
            var m = (int) Math.Sqrt(n);
            var p = PrimeUtility.PrimeSieveOfEratosthenes(m);
            
            /*var summand = new List<long>();

            for (long i = 2; i <= n; i++)
            {
                summand.Add(PrimeUtility.LargestPrimeFactorUsingSieve(i, p));
            }
            
            return summand.Sum();*/
            long sum = 0;

            for (long i = 2; i <= n; i++)
            {
                sum += PrimeUtility.LargestPrimeFactorUsingSieve(i, p);
            }
            
            return sum;
        }
    }
}