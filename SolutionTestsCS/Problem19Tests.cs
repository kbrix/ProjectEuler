using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem19Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem19.Solution();
            Assert.Equal(171, result);
        }
    }
}