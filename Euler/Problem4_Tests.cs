using Xunit;

namespace euler
{
    public class Problem4_Tests
    {
        [Fact]
        public void Reverse_String_ReturnsResult()
        {
            var result = Problem4.Reverse("BobBüldermann");
            
            Assert.Equal("nnamredlüBboB", result);
        }
        
        [Fact]
        public void Reverse_Number_ReturnsResult()
        {
            var result = Problem4.Reverse(123456789);
            
            Assert.Equal(987654321, result);
        }
        
        [Fact]
        public void IsPalindrome_Number_ReturnsResult()
        {
            var result = Problem4.IsPalindrome(9009);
            
            Assert.True(result);
        }
        
        [Fact]
        public void Solution_ReturnsResult()
        {
            var result = Problem4.Solution();
            
            Assert.Equal(906609, result);
        }
    }
}