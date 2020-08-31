using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem22Tests
    {
        [Fact]
        public void Solution_ReturnsValue()
        {
            var result = Problem22.Solution();
            Assert.Equal(871198282, result);
        }
    }
}