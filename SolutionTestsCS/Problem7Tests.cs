using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem7Tests
    {
        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem7.Solution();
            Assert.AreEqual(104743, result);
        }
    }
}