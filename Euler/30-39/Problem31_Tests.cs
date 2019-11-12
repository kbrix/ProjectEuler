using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace euler
{
    public class Problem31_Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem31.Solution(200);
            Assert.Equal(73682, result);
        }
    }
}
