using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem38Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            var result = Problem38.Solution();
            Assert.Equal(932718654, result);
        }
    }
}
