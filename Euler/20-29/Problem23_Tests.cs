using Xunit;

namespace euler
{
    public class Problem23_Tests
    {
        [Fact]
        public void Solution_ReturnsSolution()
        {
            var result = Problem23.Solution();
            Assert.Equal(4179871, result);
        }
    }
}