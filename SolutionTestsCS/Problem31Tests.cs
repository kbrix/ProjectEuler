using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem31Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem31.Solution(200);
            Assert.Equal(73682, result);
        }
    }
}
