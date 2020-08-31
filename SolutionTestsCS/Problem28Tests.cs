using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem28Tests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 3)]
        [InlineData(2, 5)]
        [InlineData(3, 7)]
        [InlineData(4, 9)]
        [InlineData(5, 13)]
        [InlineData(6, 17)]
        [InlineData(7, 21)]
        [InlineData(8, 25)]
        [InlineData(9, 31)]
        [InlineData(10, 37)]
        [InlineData(11, 43)]
        [InlineData(12, 49)]
        [InlineData(13, 57)]
        [InlineData(14, 65)]
        [InlineData(15, 73)]
        [InlineData(16, 81)]
        public static void SpiralDiagonalSequence_(int n, int x)
        {
            var element = Problem28.SpiralDiagonalSequence(n);
            Assert.Equal(x, element);
        }

        [Theory]
        [InlineData(5, 101)]
        [InlineData(1001, 669171001)]
        public static void ReturnsSolution(int n, int x)
        {
            var result = Problem28.Solution(n);
            Assert.Equal(x, result);
        }
    }
}
