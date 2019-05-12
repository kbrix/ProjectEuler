using System.Linq;
using Xunit;

namespace euler
{
    public class Problem10_Tests
    {
        [Theory]
        [InlineData(10, 17)]
        [InlineData(200000, 1709600813)]
        public static void GeneralizedSolution_TestExample_ReturnsResult(int n, long x)
        {
            var result = Problem10.GeneralizedSolution(n);
            Assert.Equal(x, result);
        }
        
        [Fact]
        public static void Solution_ReturnsResult()
        {
            var result = Problem10.Solution();
            Assert.Equal(142913828922, result);
        }
    }
}