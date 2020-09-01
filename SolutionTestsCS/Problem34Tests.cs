using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem34Tests
    {
        [Test]
        public static void Solution()
        {
            var result = Problem34.Solution();
            Assert.AreEqual(40730, result);
        }
    }
}
