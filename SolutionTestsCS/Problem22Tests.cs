using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem22Tests
    {
        [Test]
        public void Solution_ReturnsValue()
        {
            var result = Problem22.Solution();
            Assert.AreEqual(871198282, result);
        }
    }
}