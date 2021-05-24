using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem104Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            var result = Problem104.Solution();
            Assert.AreEqual(329468, result);
        }
    }
}