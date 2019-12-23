using Xunit;

namespace euler
{
    public class Problem40_Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            var result = Problem40.Solution();
            Assert.Equal(210, result);
        }
    }
}
