using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem26_Tests
    {
        [Theory]
        [InlineData(7, 6)]
        [InlineData(17, 16)]
        [InlineData(19, 18)]
        [InlineData(23, 22)]
        [InlineData(29, 28)]
        [InlineData(47, 46)]
        [InlineData(59, 58)]
        [InlineData(61, 60)]
        [InlineData(97, 96)]
        [InlineData(983, 982)]
        public static void RepeatingDigitCount_Number_ReturnsNumberOfRepeatingDigits(int n, int digitCount)
        {
            var result = Problem26.RepeatingDigitCount(n);
            Assert.Equal(digitCount, result);
        }

        [Fact]
        public static void Solution_ReturnsResult()
        {
            var result = Problem26.Solution(1000);
            Assert.Equal(983, result);
        }
    }
}
