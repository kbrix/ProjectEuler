using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem30Tests
    {
        [Test]
        public void ReturnsSolution()
        {
            var result = Problem30.Solution(5);
            Assert.AreEqual(443839, result);
        }
    }
}
