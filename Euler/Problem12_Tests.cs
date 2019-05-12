using Xunit;

namespace euler
{
    public class Problem12_Tests
    {
        [Fact]
        public void GeneralizedSolution_Example_ReturnsTriangleNumber()
        {
            var result = Problem12.GeneralizedSolution(5);
            Assert.Equal(28, result);
        }

        [Fact]
        public void Solution_SolutionForProblem12_ReturnsTriangleNumber()
        {
            var result = Problem12.Solution();
            Assert.Equal(76576500, result);
        }
    }
}