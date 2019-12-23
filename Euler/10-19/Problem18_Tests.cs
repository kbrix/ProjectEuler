using Xunit;

namespace euler
{
    public class Problem18_Tests
    {
        [Fact]
        public static void GeneralizedSolution_Example_ReturnsResult()
        {
            var result = Problem18.GeneralizedSolution(Problem18.TriangleExampleData);
            Assert.Equal(23, result);
        }

        [Fact]
        public static void GeneralizedSolution_Problem18_ReturnsResult()
        {
            var result = Problem18.GeneralizedSolution(Problem18.TriangleData);
            Assert.Equal(1074, result);
        }
    }
}