using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    // Maximum path sum II
    // https://projecteuler.net/problem=67
    public class Problem67Tests
    {
        [Fact]
        public void GeneralizedSolution_Problem67_ReturnsResult()
        {
            var result = Problem67.Solution();
            Assert.Equal(7273, result);
        }
    }
}