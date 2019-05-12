using Xunit;

namespace euler
{
    public class Problem15_Tests
    {
        [Fact]
        public void Solution_SolutionForProblem15_ReturnsResult()
        {
            var result = Problem15.Solution();
            Assert.Equal( 137846528820, result);
        }
    }
}