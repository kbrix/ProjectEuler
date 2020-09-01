using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem33Tests
    {
        [Test]
        public void ReturnsSolution()
        {
            var result = Problem33.Solution();
            Assert.AreEqual(100, result);
        }
    }
}