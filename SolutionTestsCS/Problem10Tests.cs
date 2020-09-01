using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem10Tests
    {
        [TestCase(10, 17)]
        [TestCase(200000, 1709600813)]
        public static void GeneralizedSolution_TestExample_ReturnsResult(int n, long x)
        {
            var result = Problem10.GeneralizedSolution(n);
            Assert.AreEqual(x, result);
        }
        
        [Test]
        public static void Solution_ReturnsResult()
        {
            var result = Problem10.Solution();
            Assert.AreEqual(142913828922, result);
        }
    }
}