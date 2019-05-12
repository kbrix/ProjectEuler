using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem9_Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem9.Solution();
            Assert.Equal(31875000, result);
        }
    }
}
