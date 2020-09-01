using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem38Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            var result = Problem38.Solution();
            Assert.AreEqual(932718654, result);
        }
    }
}
