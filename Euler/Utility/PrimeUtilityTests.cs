using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;
using Assert = Xunit.Assert;

namespace euler
{
    public class PrimeUtilityTests
    {
        [Fact]
        public void PrimeSieveOfEratosthenes_Integer_ReturnsPrimes()
        {
            var value = new List<int>()
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 
                61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 
                131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 
                193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 
                263, 269, 271
            };
            var result = PrimeUtility.PrimeSieveOfEratosthenes(271);
            Assert.Equal(value, result);
        }
        
        [Fact]
        public void PrimeSieveOfEratosthenes_BigInteger_ReturnsPrimes()
        {
            var value = 449243;
            var result = PrimeUtility.PrimeSieveOfEratosthenes(449244);
            Assert.Equal(value, result.Last());
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 5)]
        [InlineData(7, 7)]
        [InlineData(8, 7)]
        [InlineData(9, 7)]
        [InlineData(10, 7)]
        [InlineData(11, 11)]
        [InlineData(12, 11)]
        [InlineData(13, 13)]
        [InlineData(14, 13)]
        [InlineData(15, 13)]
        [InlineData(16, 13)]
        [InlineData(17, 17)]
        [InlineData(18, 17)]
        [InlineData(19, 19)]
        [InlineData(20, 19)]
        [InlineData(21, 19)]
        [InlineData(22, 19)]
        [InlineData(23, 23)]
        [InlineData(24, 23)]
        [InlineData(25, 23)]
        [InlineData(26, 23)]
        [InlineData(27, 23)]
        [InlineData(28, 23)]
        [InlineData(29, 29)]
        [InlineData(30, 29)]
        public void PrimeSieveOfEratosthenes_Integers_ReturnsPrimes(int x, int y)
        {
            var result = PrimeUtility.PrimeSieveOfEratosthenes(x);
            Assert.Equal(y, result.Last());
        }
        
        [Theory]
        [InlineData(8, 12, 4)]
        [InlineData(42, 56, 14)]
        [InlineData(48, 180, 12)]
        public void GreatestCommonDivisor_Integers_ReturnsResult(ulong a, ulong b, ulong value)
        {
            var result = PrimeUtility.GreatestCommonDivisor(a, b);
            Assert.Equal(value, result);
        }
        
        [Theory]
        [InlineData(600851475143, 6857)]
        [InlineData(1000000000039, 1000000000039)]
        [InlineData(2000000000039, 1958863859)]
        [InlineData(201820182018, 9901)]
        public void LargestPrimeFactor_Integers_ReturnsResult(long n, long value)
        {
            var result = PrimeUtility.LargestPrimeFactor(n);
            Assert.Equal(value, result);
        }
        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 2)]
        [InlineData(5, 5)]
        [InlineData(6, 3)]
        [InlineData(7, 7)]
        [InlineData(8, 2)]
        [InlineData(9, 3)]
        [InlineData(10, 5)]
        [InlineData(11, 11)]
        [InlineData(12, 3)]
        [InlineData(13, 13)]
        [InlineData(14, 7)]
        [InlineData(15, 5)]
        [InlineData(16, 2)]
        [InlineData(17, 17)]
        [InlineData(18, 3)]
        [InlineData(19, 19)]
        [InlineData(20, 5)]
        [InlineData(21, 7)] 
        [InlineData(22, 11)] 
        [InlineData(23, 23)] 
        [InlineData(24, 3)] 
        [InlineData(25, 5)] 
        [InlineData(26, 13)] 
        [InlineData(27, 3)] 
        [InlineData(28, 7)] 
        [InlineData(29, 29)] 
        [InlineData(30, 5)]
        public void LargestPrimeFactorNEW_Integers_ReturnsResult(long n, long value)
        {
            var p = PrimeUtility.PrimeSieveOfEratosthenes((int) Math.Sqrt(n));
            var result = PrimeUtility.LargestPrimeFactorUsingSieve(n, p);
            Assert.Equal(value, result);
        }

        [Fact]
        public void Factorize_Number_ReturnsFactors()
        {
            var factors = new List<int>(){ 1, 2, 4, 7, 14, 28 };
            var result = 28.Factorize();
            
            Assert.Equal(factors, result);
        }

        [Fact]
        public void DivisorFunction_Number_ReturnsNumberOfDivisors()
        {
            var result = 28.DivisorFunction();
            
            Assert.Equal(6, result);
        }
    }
}