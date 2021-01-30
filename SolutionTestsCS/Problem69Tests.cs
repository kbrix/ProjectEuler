using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem69Tests
    {
        [Test]
        public static void GetExample()
        {
            Assert.AreEqual(6, Problem69.Solution(10));
        }

        [Test]
        public static void GetSolution()
        {
            Assert.AreEqual(510510, Problem69.Solution(1_000_000));
        }
    }
}
