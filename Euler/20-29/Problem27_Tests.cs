using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem27_Tests
    {
        [Fact]
        public void PolynomialPrimeCounter_ExampleValue1_ReturnsResult()
        {
            var result = Problem27.PolynomialPrimeCounter(1, 41);

            Assert.Equal(40, result);
        }

        [Fact]
        public void PolynomialPrimeCounter_ExampleValue2_ReturnsResult()
        {
            var result = Problem27.PolynomialPrimeCounter(-79, 1601);

            Assert.Equal(80, result);
        }

        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem27.Solution();
            Assert.Equal(-59231, result);
        }
    }
}
