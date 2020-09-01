using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem14Tests
    {
        
        [TestCase(13, 40)]
        [TestCase(40, 20)]
        [TestCase(20, 10)]
        [TestCase(10, 5)]
        [TestCase(5, 16)]
        [TestCase(16, 8)]
        [TestCase(8, 4)]
        [TestCase(4, 2)]
        [TestCase(2, 1)]
        public void CollatzValue_ExampleNumbers_ReturnsValue(int n, int v)
        {
            var r = Problem14.CollatzValue(n);
            Assert.AreEqual(v, r);
        }

        [Test]
        public void Solution_SolutionForProblem14_ReturnsLongestCollatzChainNumber()
        {
            var result = Problem14.Solution();
            Assert.AreEqual(837799, result);
        }
        
    }
}