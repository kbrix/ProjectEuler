using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem19Tests
    {
        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem19.Solution();
            Assert.AreEqual(171, result);
        }
    }
}