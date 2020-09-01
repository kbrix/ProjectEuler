using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem39Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            Assert.AreEqual(840, Problem39.Solution());
        }
    }
}
