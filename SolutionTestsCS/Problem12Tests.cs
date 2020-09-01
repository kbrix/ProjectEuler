using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem12Tests
    {
        [Test]
        public void GeneralizedSolution_Example_ReturnsTriangleNumber()
        {
            var result = Problem12.GeneralizedSolution(5);
            Assert.AreEqual(28, result);
        }

        [Test]
        public void Solution_SolutionForProblem12_ReturnsTriangleNumber()
        {
            var result = Problem12.Solution();
            Assert.AreEqual(76576500, result);
        }
    }
}