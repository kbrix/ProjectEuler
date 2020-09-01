using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem31Tests
    {
        [Test]
        public void ReturnsSolution()
        {
            var result = Problem31.Solution(200);
            Assert.AreEqual(73682, result);
        }
    }
}
