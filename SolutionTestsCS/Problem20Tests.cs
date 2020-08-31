using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem20Tests
    {
        [Fact]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem20.GeneralizedSolution(10);
            Assert.Equal(27, result);
        }

        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem20.Solution();
            Assert.Equal(648, result);
        }
    }
}
