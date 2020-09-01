using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SolutionCS.Utility;
using NUnit.Framework;

namespace SolutionTestsCS.UtilityTests
{
    public class PrimeUtilityTests
    {
        [Test]
        public void IsPrime_PrimeNumbers_ReturnsTrue()
        {
            var primes = new List<int>()
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59,
                61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127,
                131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191,
                193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257,
                263, 269, 271
            };

            foreach (var prime in primes)
            {
                Assert.True(prime.IsPrime());
            }
        }

        [Test]
        public void IsPrime_CompositeNumbers_ReturnsFalse()
        {
            var composites = new List<int>()
            {
                4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27,
                28, 30, 32, 33, 34, 35, 36, 38, 39, 40, 42, 44, 45, 46, 48, 49,
                50, 51, 52, 54, 55, 56, 57, 58, 60, 62, 63, 64, 65, 66, 68, 69,
                70, 72, 74, 75, 76, 77, 78, 80, 81, 82, 84, 85, 86, 87, 88
            };

            foreach (var composite in composites)
            {
                Assert.False(composite.IsPrime());
            }

            Assert.False(1.IsPrime());
        }

        [Test]
        public void PrimeSieveOfEratosthenes_Integer_ReturnsPrimes()
        {
            var primes = new List<int>()
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 
                61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 
                131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 
                193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 
                263, 269, 271
            };
            var result = PrimeUtility.PrimeSieveOfEratosthenes(271);
            Assert.AreEqual(primes, result);
        }
        
        [Test]
        public void PrimeSieveOfEratosthenes_BigInteger_ReturnsPrimes()
        {
            var value = 449243;
            var result = PrimeUtility.PrimeSieveOfEratosthenes(449244);
            Assert.AreEqual(value, result.Last());
        }

        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 5)]
        [TestCase(7, 7)]
        [TestCase(8, 7)]
        [TestCase(9, 7)]
        [TestCase(10, 7)]
        [TestCase(11, 11)]
        [TestCase(12, 11)]
        [TestCase(13, 13)]
        [TestCase(14, 13)]
        [TestCase(15, 13)]
        [TestCase(16, 13)]
        [TestCase(17, 17)]
        [TestCase(18, 17)]
        [TestCase(19, 19)]
        [TestCase(20, 19)]
        [TestCase(21, 19)]
        [TestCase(22, 19)]
        [TestCase(23, 23)]
        [TestCase(24, 23)]
        [TestCase(25, 23)]
        [TestCase(26, 23)]
        [TestCase(27, 23)]
        [TestCase(28, 23)]
        [TestCase(29, 29)]
        [TestCase(30, 29)]
        public void PrimeSieveOfEratosthenes_Integers_ReturnsPrimes(int x, int y)
        {
            var result = PrimeUtility.PrimeSieveOfEratosthenes(x);
            Assert.AreEqual(y, result.Last());
        }

        private static IEnumerable<TestCaseData> GreatestCommonDivisor_Integers_Data
        {
            get
            {
                yield return new TestCaseData((BigInteger)8, (BigInteger)12, (BigInteger)4);
                yield return new TestCaseData((BigInteger)42, (BigInteger)56, (BigInteger)14);
                yield return new TestCaseData((BigInteger)48, (BigInteger)180, (BigInteger)12);
            }
        }

        [Test, TestCaseSource(nameof(GreatestCommonDivisor_Integers_Data))]
        public void GreatestCommonDivisor_Integers_ReturnsResult(BigInteger a, BigInteger b, BigInteger value)
        {
            var result = PrimeUtility.GreatestCommonDivisor(a, b);
            Assert.AreEqual(value, result);
        }


        [TestCase(600851475143, 6857)]
        [TestCase(1000000000039, 1000000000039)]
        [TestCase(2000000000039, 1958863859)]
        [TestCase(201820182018, 9901)]
        public void LargestPrimeFactor_Integers_ReturnsResult(long n, long value)
        {
            var result = PrimeUtility.LargestPrimeFactor(n);
            Assert.AreEqual(value, result);
        }
        
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 2)]
        [TestCase(5, 5)]
        [TestCase(6, 3)]
        [TestCase(7, 7)]
        [TestCase(8, 2)]
        [TestCase(9, 3)]
        [TestCase(10, 5)]
        [TestCase(11, 11)]
        [TestCase(12, 3)]
        [TestCase(13, 13)]
        [TestCase(14, 7)]
        [TestCase(15, 5)]
        [TestCase(16, 2)]
        [TestCase(17, 17)]
        [TestCase(18, 3)]
        [TestCase(19, 19)]
        [TestCase(20, 5)]
        [TestCase(21, 7)] 
        [TestCase(22, 11)] 
        [TestCase(23, 23)] 
        [TestCase(24, 3)] 
        [TestCase(25, 5)] 
        [TestCase(26, 13)] 
        [TestCase(27, 3)] 
        [TestCase(28, 7)] 
        [TestCase(29, 29)] 
        [TestCase(30, 5)]
        public void LargestPrimeTestCaseorNEW_Integers_ReturnsResult(long n, long value)
        {
            var p = PrimeUtility.PrimeSieveOfEratosthenes((int) Math.Sqrt(n));
            var result = PrimeUtility.LargestPrimeFactorUsingSieve(n, p);
            Assert.AreEqual(value, result);
        }
        
        [Test]
        public void Divisors_Number_ReturnsDivisors()
        {
            var divisors = new List<int>(){ 1, 2, 4, 7, 14, 28 };
            var result = 28.Divisors();
            
            Assert.AreEqual(divisors, result);
        }
        
        [Test]
        public void ProperDivisors_Number_ReturnsProperDivisors()
        {
            var properDivisors = new List<int>(){ 1, 2, 4, 7, 14 };
            var result = 28.ProperDivisors();
            
            Assert.AreEqual(properDivisors, result);
        }
        
        [Test]
        public void Divisors_Number1_ReturnsDivisors()
        {
            var divisors = new List<int>(){ 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110, 220 };
            var result = 220.Divisors();
            
            Assert.AreEqual(divisors, result);
        }
        
        [Test]
        public void Divisors_Number2_ReturnsDivisors()
        {
            var divisors = new List<int>(){ 1, 2, 4, 71, 142, 284 };
            var result = 284.Divisors();
            
            Assert.AreEqual(divisors, result);
        }
        
        [Test]
        public void FactorCounter_Number_ReturnsNumberOfDivisors()
        {
            var result = 28.FactorCounter();
            
            Assert.AreEqual(6, result);
        }
        
        [Test]
        public void GetNumberOfDivisors_Number_ReturnsNumberOfDivisors()
        {
            var result = 28.GetNumberOfDivisors();
            
            Assert.AreEqual(6, result);
        }
    }
}