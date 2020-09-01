using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem40Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            var result = Problem40.Solution();
            Assert.AreEqual(210, result);
        }
    }
}
