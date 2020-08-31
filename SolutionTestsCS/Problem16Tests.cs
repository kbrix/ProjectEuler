using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem16Tests
    {
        [Fact]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem16.GeneralizedSolution(15);
            Assert.Equal(26, result);
        }

        [Fact]
        public void GeneralizedSolution_ProblemValue_RetrunsResult()
        {
            var result = Problem16.GeneralizedSolution(1000);
            Assert.Equal(1366, result);
        }
    }
}