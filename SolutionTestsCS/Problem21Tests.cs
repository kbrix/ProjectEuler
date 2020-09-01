using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem21Tests
    {
        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem21.Solution();
            Assert.AreEqual(31626, result);
        }
    }
}