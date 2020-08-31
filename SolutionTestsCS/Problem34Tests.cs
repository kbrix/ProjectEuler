using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem34Tests
    {
        [Fact]
        public static void Solution()
        {
            var result = Problem34.Solution();
            Assert.Equal(40730, result);
        }
    }
}
