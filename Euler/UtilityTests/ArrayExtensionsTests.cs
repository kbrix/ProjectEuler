using System;
using System.Collections.Generic;
using System.Text;
using euler.Utility;
using Xunit;

namespace euler.UtilityTests
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void Sum_Array_ReturnsSum()
        {
            var a = new int[] {1, 2, 3, 4};
            var result = a.Product();
            Assert.Equal(24, result);
        }
    }
}
