using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem39Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            Assert.Equal(840, Problem39.Solution());
        }
    }
}
