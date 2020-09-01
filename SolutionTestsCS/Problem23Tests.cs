using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem23Tests
    {
        [Test]
        public void Solution_ReturnsSolution()
        {
            var result = Problem23.Solution();
            Assert.AreEqual(4179871, result);
        }
    }
}