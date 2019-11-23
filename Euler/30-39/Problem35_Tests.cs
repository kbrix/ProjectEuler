using System.Collections.Generic;
using System.Linq;
using euler.Utility;
using Xunit;

namespace euler
{
    public class Problem35_Tests
    {
        [Theory]
        [InlineData(197)]
        [InlineData(971)]
        [InlineData(719)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(17)]
        [InlineData(31)]
        [InlineData(37)]
        [InlineData(71)]
        [InlineData(73)]
        [InlineData(79)]
        [InlineData(97)]
        public void IsCircularPrime_CircularPrime_ReturnsTrue(int n)
        {
            Assert.True(Problem35.IsCircularPrime(n));
        }

        [Theory]
        [InlineData(101)]
        public void IsCircularPrime_NonCircularPrime_ReturnsFalse(int n)
        {
            Assert.False(Problem35.IsCircularPrime(n));
        }

        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem35.Solution();
            Assert.Equal(55, result);
        }
    }
}
