using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem11Tests
    {
        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem11.Solution();
            Assert.AreEqual(70600674, result);
        }
    }
}