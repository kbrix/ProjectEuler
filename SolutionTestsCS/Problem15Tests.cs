using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem15Tests
    {
        [Fact]
        public void Solution_SolutionForProblem15_ReturnsResult()
        {
            var result = Problem15.Solution();
            Assert.Equal( 137846528820, result);
        }
    }
}