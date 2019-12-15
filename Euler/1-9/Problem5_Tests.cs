using Xunit;

namespace euler
{
    public class Problem5_Tests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void IsEvenlyDivisbleBy_Number_ReturnsResult(int n)
        {
            var x = 2520;
            var result = x.IsEvenlyDivisibleBy(n);
            Assert.True(result);
        }
        
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem5.Solution();
            
            Assert.Equal(232792560, result);
        }
    }
}