using Xunit;

namespace euler
{
    public class Problem32_Tests
    {
        [Fact]
        public void IsPandigital_PandigitalTriplet_ReturnsTrue()
        {
            var result = Problem32.IsPandigital(39, 186, 7254);
            Assert.True(result);
        }

        [Fact]
        public void IsPandigital_NonPandigitalTriplet_ReturnsFalse()
        {
            var result = Problem32.IsPandigital(2, 6794, 13588);
            Assert.False(result);
        }

        [Fact]
        public void Solution()
        {
            var result = Problem32.Solution();
            Assert.Equal(45228, result);
        }
    }
}
