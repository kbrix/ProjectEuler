using Xunit;

namespace euler
{
    public class Problem37_Test
    {
        [Fact]
        public void ReturnsSolution()
        {
            Assert.Equal(748317, Problem37.Solution());
        }
    }
}
