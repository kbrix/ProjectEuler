using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem11Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem11.Solution();
            Assert.Equal(70600674, result);
        }
    }
}