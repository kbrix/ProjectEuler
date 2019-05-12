using Xunit;

namespace euler
{
    public class Problem2_Tests
    {
        [Fact]
        public void Solution_SolutionForProblem2_ReturnsResult()
        {
            var result = Problem2.Solution();
            Assert.Equal(4613732, result);
        }
    }
}