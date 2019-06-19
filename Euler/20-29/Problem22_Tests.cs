using Xunit;

namespace euler
{
    public class Problem22_Tests
    {
        [Fact]
        public void Solution_ReturnsValue()
        {
            var result = Problem22.Solution();
            Assert.Equal(871198282, result);
        }
    }
}