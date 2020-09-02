using NUnit.Framework;

namespace SolutionTestsCS
{
    class Problem43Tests
    {
        [Test]
        public void DivisibilityCondition_ExampleValue_ReturnsTrue()
        {
            var value = SolutionCS.Problem43.DivisibilityCondition(1406357289);
            Assert.True(value);
        }

        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(16695334890, SolutionCS.Problem43.Solution());
        }
    }
}
