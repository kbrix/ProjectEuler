using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem21Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem21.Solution();
            Assert.Equal(31626, result);
        }
    }
}