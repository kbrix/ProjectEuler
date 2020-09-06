using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem49Tests
    {
        [TestCase(1487)]
        [TestCase(4817)]
        [TestCase(8147)]
        public void GetPrimePermutationSequence_Example_ReturnsResult(int n)
        {
            var result = n.GetPrimePermutationSequence();
            Assert.AreEqual(148748178147L, result);
        }

        [Test]
        public void ReturnsSolution()
        {
            var result = Problem49.Solution();
            Assert.AreEqual(296962999629L, result);
        }
    }
}
