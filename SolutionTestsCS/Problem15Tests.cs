using System.Numerics;
using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem15Tests
    {
        [Test]
        public void Solution_SolutionForProblem15_ReturnsResult()
        {
            var result = Problem15.Solution();
            Assert.AreEqual((BigInteger) 137846528820, result);
        }
    }
}