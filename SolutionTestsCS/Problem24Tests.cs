using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem24Tests
    {
        [Test]
        public void Solution_ReturnsSolution()
        {
            var result = Problem24.Solution();
            Assert.AreEqual("2783915460", result);
        }
    }
}