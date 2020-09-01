using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem37Test
    {
        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(748317, Problem37.Solution());
        }
    }
}
