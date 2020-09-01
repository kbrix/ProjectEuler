using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem16Tests
    {
        [Test]
        public void GeneralizedSolution_ExampleValue_ReturnsResult()
        {
            var result = Problem16.GeneralizedSolution(15);
            Assert.AreEqual(26, result);
        }

        [Test]
        public void GeneralizedSolution_ProblemValue_RetrunsResult()
        {
            var result = Problem16.GeneralizedSolution(1000);
            Assert.AreEqual(1366, result);
        }
    }
}