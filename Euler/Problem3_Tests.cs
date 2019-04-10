using Xunit;

namespace euler
{
    public class Problem_3_Tests
    {
        [Fact]
        public void Solution_Answer_ReturnsResult()
        {
            var result = Problem3.Solution();
            
            Assert.Equal(6857, result);
        }
    }
}