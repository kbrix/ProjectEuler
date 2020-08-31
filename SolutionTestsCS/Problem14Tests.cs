using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem14Tests
    {
        [Theory]
        [InlineData(13, 40)]
        [InlineData(40, 20)]
        [InlineData(20, 10)]
        [InlineData(10, 5)]
        [InlineData(5, 16)]
        [InlineData(16, 8)]
        [InlineData(8, 4)]
        [InlineData(4, 2)]
        [InlineData(2, 1)]
        public void CollatzValue_ExampleNumbers_ReturnsValue(int n, int v)
        {
            var r = Problem14.CollatzValue(n);
            Assert.Equal(v, r);
        }

        [Fact]
        public void Solution_SolutionForProblem14_ReturnsLongestCollatzChainNumber()
        {
            var result = Problem14.Solution();
            Assert.Equal(837799, result);
        }
        
    }
}