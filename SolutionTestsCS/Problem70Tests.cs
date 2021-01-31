using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public static class Problem70Tests
    {
        [Test]
        public static void GetSolution()
        {
            Assert.AreEqual(8319823, Problem70.Solution(10_000_000));
        }
    }
}
