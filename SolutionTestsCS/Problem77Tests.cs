using System.Numerics;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem77Tests
    {
        [Test]
        public void GetSolution()
        {
            Assert.AreEqual(71, Problem77.Solution());
        }
    }
}
