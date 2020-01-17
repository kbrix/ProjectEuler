using Xunit;

namespace euler
{
    public class Problem39_Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            Assert.Equal(840, Problem39.Solution());
        }
    }
}
