using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem32Tests
    {
        [Test]
        public void IsPandigital_PandigitalTriplet_ReturnsTrue()
        {
            var result = Problem32.IsPandigital(39, 186, 7254);
            Assert.True(result);
        }

        [Test]
        public void IsPandigital_NonPandigitalTriplet_ReturnsFalse()
        {
            var result = Problem32.IsPandigital(2, 6794, 13588);
            Assert.False(result);
        }

        [Test]
        public void Solution()
        {
            var result = Problem32.Solution();
            Assert.AreEqual(45228, result);
        }
    }
}
