using Xunit;

namespace euler
{
    public class Problem30_Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem30.Solution(4);
            Assert.Equal(1, result);
        }
    }
}
