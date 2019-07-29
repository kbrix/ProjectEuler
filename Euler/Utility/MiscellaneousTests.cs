using Xunit;

namespace euler.Utility
{
    public class MiscellaneousTests
    {
        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 2)]
        [InlineData('C', 3)]
        [InlineData('D', 4)]
        [InlineData('E', 5)]
        [InlineData('F', 6)]
        [InlineData('G', 7)]
        [InlineData('H', 8)]
        [InlineData('I', 9)]
        [InlineData('J', 10)]
        [InlineData('K', 11)]
        [InlineData('L', 12)]
        [InlineData('M', 13)]
        [InlineData('N', 14)]
        [InlineData('O', 15)]
        [InlineData('P', 16)]
        [InlineData('Q', 17)]
        [InlineData('R', 18)]
        [InlineData('S', 19)]
        [InlineData('T', 20)]
        [InlineData('U', 21)]
        [InlineData('V', 22)]
        [InlineData('W', 23)]
        [InlineData('X', 24)]
        [InlineData('Y', 25)]
        [InlineData('Z', 26)]
        public void ConvertLetterToNumber_Letter_ReturnsAlphabeticalPosition(char x, int y)
        {
            var result = Miscellaneous.ConvertLetterToNumber(x);
            Assert.Equal(y, result);
        }

        [Theory]
        [InlineData(23, 5)]
        [InlineData(60, 6)]
        [InlineData(64, 10)]
        [InlineData(1111, 4)]
        [InlineData(1000000001, 2)]
        public void DigitSum_Number_ReturnsDigitSum(int x, int a)
        {
            var result = x.DigitSum();
            Assert.Equal(a, result);
        }
    }
}