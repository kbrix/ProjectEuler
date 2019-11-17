using Xunit;

namespace euler
{
    public class Problem34_Tests
    {
        [Fact]
        public static void Solution()
        {
            var result = Problem34.Solution();
            Assert.Equal(40730, result);
        }
    }
}
