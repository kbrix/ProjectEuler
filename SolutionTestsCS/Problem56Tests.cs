using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem56Tests
    {
        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(972, Problem56.Solution());
        }
    }
}
