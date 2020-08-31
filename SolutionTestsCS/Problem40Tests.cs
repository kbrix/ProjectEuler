using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem40Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            var result = Problem40.Solution();
            Assert.Equal(210, result);
        }
    }
}
