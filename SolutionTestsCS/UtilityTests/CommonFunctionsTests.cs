using System.Numerics;
using SolutionCS.Utility;
using Xunit;

namespace SolutionTestsCS.UtilityTests
{
    public class CommonFunctionsTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        [InlineData(7, 5040)]
        [InlineData(8, 40320)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        [InlineData(20, 2432902008176640000)]
        public void Factorial_NaturalNumber_ReturnsResult(BigInteger n, BigInteger x)
        {
            var result = n.Factorial();
            Assert.Equal(x, result);

        }

        [Fact]
        public void BinomialCoefficient_PairsOfNaturalNumbers_ReturnsResult()
        {
            var value = new BigInteger[,]
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 4, 6, 4, 1, 0, 0, 0, 0, 0, 0 },
                { 5, 10, 10, 5, 1, 0, 0, 0, 0, 0 },
                { 6, 15, 20, 15, 6, 1, 0, 0, 0, 0 },
                { 7, 21, 35, 35, 21, 7, 1, 0, 0, 0 },
                { 8, 28, 56, 70, 56, 28, 8, 1, 0, 0 },
                { 9, 36, 84, 126, 126, 84, 36, 9, 1, 0 },
                { 10, 45, 120, 210, 252, 210, 120, 45, 10, 1 },
            };
            
            var result = new BigInteger[10, 10];
            
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    result[i, j] = CommonFunctions.BinomialCoefficient(i + 1, j + 1);
                }
            }
            
            Assert.Equal(value, result);
        }
    }
}