using Xunit;

namespace euler
{
    public class Problem1_Tests
    {
        [Theory]
        [InlineData(9, 3)]
        [InlineData(10, 2)]
        [InlineData(10, 5)]
        [InlineData(10, 10)]
        [InlineData(12, 2)]
        [InlineData(12, 3)]
        [InlineData(12, 6)]
        public void IsMultiplesOfInteger_Integers_ReturnsTrue(int x, int n)
        {
            var result = Problem1.IsMultiplesOfInteger(x, n);
            
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(9, 2)]
        [InlineData(10, 3)]
        [InlineData(10, 6)]
        [InlineData(10, 11)]
        public void IsMultiplesOfInteger_Integers_ReturnsFalse(int x, int n)
        {
            var result = Problem1.IsMultiplesOfInteger(x, n);
            
            Assert.False(result);
        }

        [Fact]
        public void Solution_Example_ReturnsResult()
        {
            var result = Problem1.Solution(10);
            
            Assert.Equal(23, result);
        }
        
        [Fact]
        public void Solution_Answer_ReturnsResult()
        {
            var result = Problem1.Solution(1000);
            
            Assert.Equal(233168, result);
        }
    }
}