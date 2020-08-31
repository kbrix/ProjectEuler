using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    // Distinct powers, https://projecteuler.net/problem=29
    public class Problem29Tests
    {
        [Fact]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem29.GeneralizedSolution(5, 5);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem29.Solution();
            Assert.Equal(9183, result);
        }
    }
}
