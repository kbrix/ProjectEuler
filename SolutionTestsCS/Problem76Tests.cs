using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem76Tests
    {
        [Test]
        public void GetSolution()
        {
            Assert.AreEqual(190569291, Problem76.Solution());
        }
    }
}
