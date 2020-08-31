using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem23Tests
    {
        [Fact]
        public void Solution_ReturnsSolution()
        {
            var result = Problem23.Solution();
            Assert.Equal(4179871, result);
        }
    }
}