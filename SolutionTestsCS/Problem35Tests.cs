using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem35Tests
    {
        [TestCase(197)]
        [TestCase(971)]
        [TestCase(719)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(17)]
        [TestCase(31)]
        [TestCase(37)]
        [TestCase(71)]
        [TestCase(73)]
        [TestCase(79)]
        [TestCase(97)]
        public void IsCircularPrime_CircularPrime_ReturnsTrue(int n)
        {
            Assert.True(Problem35.IsCircularPrime(n));
        }

        [TestCase(101)]
        public void IsCircularPrime_NonCircularPrime_ReturnsFalse(int n)
        {
            Assert.False(n.IsCircularPrime());
        }

        [Test]
        public void ReturnsSolution()
        {
            var result = Problem35.Solution();
            Assert.AreEqual(55, result);
        }
    }
}
