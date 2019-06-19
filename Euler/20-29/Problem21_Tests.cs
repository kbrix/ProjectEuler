using Xunit;

namespace euler
{
    public class Problem21_Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem21.Solution();
            Assert.Equal(31626, result);
        }
    }
}