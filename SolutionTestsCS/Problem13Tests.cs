using System.Numerics;
using SolutionCS;
using Xunit;

namespace SolutionTestsCS
{
    public class Problem13Tests
    {
        [Fact]
        public static void Solution_SolutionForProblem13_ReturnsFullSum()
        {
            var result = Problem13.Solution();
            Assert.Equal(BigInteger.Parse("5537376230390876637302048746832985971773659831892672"), result);
        }
    }
}