using Xunit;

namespace euler
{
    public class Problem11_Tests
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem11.Solution();
            Assert.Equal(70600674, result);
        }
    }
}