using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem7Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem7.Solution();
            Assert.Equal(104743, result);
        }
    }
}