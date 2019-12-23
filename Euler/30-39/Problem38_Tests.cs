using Xunit;

namespace euler
{
    public class Problem38_Tests
    {
        [Fact]
        public static void ReturnsSolution()
        {
            var result = Problem38.Solution();
            Assert.Equal(932718654, result);
        }
    }
}
