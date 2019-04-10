using System.Numerics;
using Xunit;
using Assert = Xunit.Assert;

namespace euler
{
    public class PrimeUtilityTests
    {
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

        public void kpqwkd(long n, long value)
        {
            var result = PrimeUtility.kook(n);
            Assert.Equal(value, result);
        }
        
        [Theory]
        [InlineData(600851475143, 6857)]
        [InlineData(1000000000039, 1000000000039)]
        [InlineData(2000000000039, 1958863859)]
        [InlineData(201820182018, 9901)]

        public void qd(long n, long value)
        {
            var result = PrimeUtility.kook2(n);
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
        
    }
}