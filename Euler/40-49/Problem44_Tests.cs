using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem44_Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            var result = Problem44.Solution(); // pentagonNumber[2167] = 7042750, pentagonNumber[1020] = 1560090
            Assert.Equal(5482660, result);
        }
    }
}
