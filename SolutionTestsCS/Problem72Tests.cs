using System.Numerics;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem72Tests
    {
        [Test]
        public void GetExample()
        {
            var expectedResult = new BigInteger(21);
            Assert.AreEqual(expectedResult, Problem72.Solution(8));
        }

        [Test]
        public void GetSolution()
        {
            var expectedResult = new BigInteger(303_963_552_391);
            Assert.AreEqual(expectedResult, Problem72.Solution(1_000_000));
        }
    }
}
