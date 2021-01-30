using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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

        private static IEnumerable<TestCaseData> PrimeFactors_Integers_Data
        {
            get
            {
                yield return new TestCaseData(14, new List<int> { 2, 7 });
                yield return new TestCaseData(15, new List<int> { 3, 5 });
                yield return new TestCaseData(644, new List<int> { 2, 2, 7, 23 });
                yield return new TestCaseData(645, new List<int> { 3, 5, 43 });
                yield return new TestCaseData(646, new List<int> { 2, 17, 19 });
            }
        }

        [Test, TestCaseSource(nameof(PrimeFactors_Integers_Data))]
        public void PrimeFactors_Integers_ReturnsPrimeFactors(int n, List<int> result)
        {
            CollectionAssert.AreEqual(result, n.PrimeFactors());
        }

        private static IEnumerable<TestCaseData> PrimeFactors_Longs_Data
        {
            get
            {
                yield return new TestCaseData(18848997161L, new List<long> { 18848997161L });
            }
        }

        [Test, TestCaseSource(nameof(PrimeFactors_Longs_Data))]
        public void PrimeFactors_Longs_ReturnsPrimeFactors(long n, List<long> result)
        {
            CollectionAssert.AreEqual(result, n.PrimeFactors());
        }

        private static IEnumerable<TestCaseData> EulerTotientFunction_Ints_Data
        {
            get
            {
                yield return new TestCaseData(1, 1);
                yield return new TestCaseData(2, 1);
                yield return new TestCaseData(3, 2);
                yield return new TestCaseData(4, 2);
                yield return new TestCaseData(5, 4);
                yield return new TestCaseData(6, 2);
                yield return new TestCaseData(7, 6);
                yield return new TestCaseData(8, 4);
                yield return new TestCaseData(9, 6);
                yield return new TestCaseData(10, 4);
                yield return new TestCaseData(11, 10);
                yield return new TestCaseData(12, 4);
                yield return new TestCaseData(13, 12);
                yield return new TestCaseData(14, 6);
                yield return new TestCaseData(15, 8);
                yield return new TestCaseData(16, 8);
                yield return new TestCaseData(17, 16);
                yield return new TestCaseData(18, 6);
                yield return new TestCaseData(19, 18);
                yield return new TestCaseData(20, 8);
                yield return new TestCaseData(21, 12);
                yield return new TestCaseData(22, 10);
                yield return new TestCaseData(23, 22);
                yield return new TestCaseData(24, 8);
                yield return new TestCaseData(25, 20);
                yield return new TestCaseData(26, 12);
                yield return new TestCaseData(27, 18);
                yield return new TestCaseData(28, 12);
                yield return new TestCaseData(29, 28);
                yield return new TestCaseData(30, 8);
                yield return new TestCaseData(31, 30);
                yield return new TestCaseData(32, 16);
                yield return new TestCaseData(33, 20);
                yield return new TestCaseData(34, 16);
                yield return new TestCaseData(35, 24);
                yield return new TestCaseData(36, 12);
                yield return new TestCaseData(37, 36);
                yield return new TestCaseData(38, 18);
                yield return new TestCaseData(39, 24);
                yield return new TestCaseData(40, 16);
                yield return new TestCaseData(41, 40);
                yield return new TestCaseData(42, 12);
                yield return new TestCaseData(43, 42);
                yield return new TestCaseData(44, 20);
                yield return new TestCaseData(45, 24);
                yield return new TestCaseData(46, 22);
                yield return new TestCaseData(47, 46);
                yield return new TestCaseData(48, 16);
                yield return new TestCaseData(49, 42);
                yield return new TestCaseData(50, 20);
                yield return new TestCaseData(51, 32);
                yield return new TestCaseData(52, 24);
                yield return new TestCaseData(53, 52);
                yield return new TestCaseData(54, 18);
                yield return new TestCaseData(55, 40);
                yield return new TestCaseData(56, 24);
                yield return new TestCaseData(57, 36);
                yield return new TestCaseData(58, 28);
                yield return new TestCaseData(59, 58);
                yield return new TestCaseData(60, 16);
                yield return new TestCaseData(61, 60);
                yield return new TestCaseData(62, 30);
                yield return new TestCaseData(63, 36);
                yield return new TestCaseData(64, 32);
                yield return new TestCaseData(65, 48);
                yield return new TestCaseData(66, 20);
                yield return new TestCaseData(67, 66);
                yield return new TestCaseData(68, 32);
                yield return new TestCaseData(69, 44);
                yield return new TestCaseData(70, 24);
                yield return new TestCaseData(71, 70);
                yield return new TestCaseData(72, 24);
                yield return new TestCaseData(73, 72);
                yield return new TestCaseData(74, 36);
                yield return new TestCaseData(75, 40);
                yield return new TestCaseData(76, 36);
                yield return new TestCaseData(77, 60);
                yield return new TestCaseData(78, 24);
                yield return new TestCaseData(79, 78);
                yield return new TestCaseData(80, 32);
                yield return new TestCaseData(81, 54);
                yield return new TestCaseData(82, 40);
                yield return new TestCaseData(83, 82);
                yield return new TestCaseData(84, 24);
                yield return new TestCaseData(85, 64);
                yield return new TestCaseData(86, 42);
                yield return new TestCaseData(87, 56);
                yield return new TestCaseData(88, 40);
                yield return new TestCaseData(89, 88);
                yield return new TestCaseData(90, 24);
                yield return new TestCaseData(91, 72);
                yield return new TestCaseData(92, 44);
                yield return new TestCaseData(93, 60);
                yield return new TestCaseData(94, 46);
                yield return new TestCaseData(95, 72);
                yield return new TestCaseData(96, 32);
                yield return new TestCaseData(97, 96);
                yield return new TestCaseData(98, 42);
                yield return new TestCaseData(99, 60);
                yield return new TestCaseData(100, 40);
            }
        }

        [Test, TestCaseSource(nameof(EulerTotientFunction_Ints_Data))]
        public void EulerTotientFunction_Ints_ReturnsCount(int n, int result)
        {
            Assert.AreEqual(result, n.EulerTotientFunction());
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