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
        [InlineData(23, 1, 5)]
        [InlineData(60, 1, 6)]
        [InlineData(64, 1, 10)]
        [InlineData(1111, 1, 4)]
        [InlineData(1000000001, 1, 2)]
        [InlineData(121, 5, 34)]
        public void DigitSum_Number_ReturnsDigitSum(int x, int p, int a)
        {
            var result = x.DigitSum(p);
            Assert.Equal(a, result);
        }

        [Theory]
        [InlineData(3797, 0, 3797)]
        [InlineData(3797, 1, 797)]
        [InlineData(3797, 2, 97)]
        [InlineData(3797, 3, 7)]
        public void TruncateLeftToRight_Number_ReturnsTruncatedNumber(int number, int step, int result)
        {
            Assert.Equal(result, number.TruncateLeftToRight(step));
        }

        [Theory]
        [InlineData(3797, 0, 3797)]
        [InlineData(3797, 1, 379)]
        [InlineData(3797, 2, 37)]
        [InlineData(3797, 3, 3)]
        public void TruncateRightToLeft_Number_ReturnsTruncatedNumber(int number, int step, int result)
        {
            Assert.Equal(result, number.TruncateRightToLeft(step));
        }
    }
}