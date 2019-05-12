using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem8_Tests
    {
        [Fact]
        public static void GeneralizedSolution_Example_ReturnsResult()
        {
            var result = Problem8.GeneralizedSolution(4);
            Assert.Equal(5832, result);
        }

        [Fact]
        public static void Solution_ReturnsResult()
        {
            var result = Problem8.Solution();
            Assert.Equal(23514624000, result);
        }
    }
}
