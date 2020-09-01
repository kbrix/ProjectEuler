using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem20Tests
    {
        [Test]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem20.GeneralizedSolution(10);
            Assert.AreEqual(27, result);
        }

        [Test]
        public void Solution_ReturnsResult()
        {
            var result = Problem20.Solution();
            Assert.AreEqual(648, result);
        }
    }
}
