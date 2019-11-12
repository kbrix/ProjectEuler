using Xunit;

namespace euler
{
    public class Problem33_Tests
    {
        [Fact]
        public void ReturnsSolution()
        {
            var result = Problem33.Solution();
            Assert.Equal(1, result);
        }
    }
}