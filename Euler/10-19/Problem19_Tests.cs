using Xunit;

namespace euler
{
    public class Problem19_Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem19.Solution();
            Assert.Equal(171, result);
        }
    }
}