using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem53Tests
    {
        [Test]
        public void ReturnsSolution()
        {
            var solution = Problem53.Solution();
            Assert.AreEqual(4075, solution);
        }
    }
}
