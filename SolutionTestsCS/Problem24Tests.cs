using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem24Tests
    {
        [Fact]
        public void Solution_ReturnsSolution()
        {
            var result = Problem24.Solution();
            Assert.Equal("2783915460", result);
        }
    }
}