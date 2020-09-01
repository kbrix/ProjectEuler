using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem18_Tests
    {
        [Test]
        public static void GeneralizedSolution_Example_ReturnsResult()
        {
            var result = Problem18.GeneralizedSolution(Problem18.TriangleExampleData);
            Assert.AreEqual(23, result);
        }

        [Test]
        public static void GeneralizedSolution_Problem18_ReturnsResult()
        {
            var result = Problem18.GeneralizedSolution(Problem18.TriangleData);
            Assert.AreEqual(1074, result);
        }
    }
}