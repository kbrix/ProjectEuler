using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem27Tests
    {
        [Test]
        public void PolynomialPrimeCounter_ExampleValue1_ReturnsResult()
        {
            var result = Problem27.PolynomialPrimeCounter(1, 41);

            Assert.AreEqual(40, result);
        }

        [Test]
        public void PolynomialPrimeCounter_ExampleValue2_ReturnsResult()
        {
            var result = Problem27.PolynomialPrimeCounter(-79, 1601);

            Assert.AreEqual(80, result);
        }

        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem27.Solution();
            Assert.AreEqual(-59231, result);
        }
    }
}
