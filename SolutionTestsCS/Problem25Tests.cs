using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    // 1000-digit Fibonacci number, https://projecteuler.net/problem=25
    public class Problem25Tests
    {
        [Fact]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var value = Problem25.GeneralizedSolution(2);
            Assert.Equal(12, value);
        }

        [Fact]
        public void Solution_ReturnsResult()
        {
            var value = Problem25.Solution();
            Assert.Equal(4782, value);
        }
    }
}