using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem30Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem30.Solution(5);
            Assert.Equal(443839, result);
        }
    }
}
