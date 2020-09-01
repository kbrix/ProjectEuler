using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    // Maximum path sum II
    // https://projecteuler.net/problem=67
    public class Problem67Tests
    {
        [Test]
        public void GeneralizedSolution_Problem67_ReturnsResult()
        {
            var result = Problem67.Solution();
            Assert.AreEqual(7273, result);
        }
    }
}