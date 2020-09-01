using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    // 1000-digit Fibonacci number, https://projecteuler.net/problem=25
    public class Problem25Tests
    {
        [Test]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var value = Problem25.GeneralizedSolution(2);
            Assert.AreEqual(12, value);
        }

        [Test]
        public void Solution_ReturnsResult()
        {
            var value = Problem25.Solution();
            Assert.AreEqual(4782, value);
        }
    }
}