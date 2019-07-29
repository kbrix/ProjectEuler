using Xunit;

namespace euler
{
    public class Problem30_Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem30.Solution(5);
            Assert.Equal(443839, result);
        }
    }
}
