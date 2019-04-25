using Xunit;

namespace euler
{
    public class Problem7_Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem7.Solution();
            Assert.Equal(104743, result);
        }
    }
}