using Xunit;

namespace euler
{
    public class Problem24_Tests
    {
        [Fact]
        public void Solution_ReturnsSolution()
        {
            var result = Problem24.Solution();
            Assert.Equal("2783915460", result);
        }
    }
}