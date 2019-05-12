using Xunit;

namespace euler
{
    public class Problem6_Test
    {
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem6.Solution();
            Assert.Equal(25164150, result);
        }
    }
}