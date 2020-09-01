using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    // Distinct powers, https://projecteuler.net/problem=29
    public class Problem29Tests
    {
        [Test]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem29.GeneralizedSolution(5, 5);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem29.Solution();
            Assert.AreEqual(9183, result);
        }
    }
}
