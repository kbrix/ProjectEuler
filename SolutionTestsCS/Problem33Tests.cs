using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem33Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem33.Solution();
            Assert.Equal(100, result);
        }
    }
}