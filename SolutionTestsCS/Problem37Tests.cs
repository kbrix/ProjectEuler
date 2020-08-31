using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem37Test
    {
        [Fact]
        public void ReturnsSolution()
        {
            Assert.Equal(748317, Problem37.Solution());
        }
    }
}
