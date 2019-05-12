using Xunit;

namespace euler
{
    public class Problem642_Tests
    {
        [Theory]
        [InlineData(10, 32)] // 10^1
        [InlineData(100, 1915)] // 10^2
        [InlineData(10000, 10118280)] //10^4
        [InlineData(100000, 793111753)] //10^5
        [InlineData(1000000, 64937323262)] //10^6, 2.5 sec
        //[InlineData(10000000, 5494366736156)] //10^7, 1 min 4 sec
        //[InlineData(100000000, 476001412898167)] //10^8, 28 min 58 sec
        public void SolutionForArbitraryInput_TestExample_ReturnsResult(long n, long value)
        {
            var result = Problem642.SolutionForArbitraryInput(n);
            Assert.Equal(value, result);
        }
        
        // 201820182018 = 2.0182e+11
        [Theory]
        [InlineData(10, 32)] // 10^1
        [InlineData(100, 1915)] // 10^2
        [InlineData(10000, 10118280)] //10^4
        [InlineData(100000, 793111753)] //10^5
        [InlineData(1000000, 64937323262)] //10^6, 2.5 sec
        //[InlineData(10000000, 5494366736156)] //10^7, 1 min 6 sec
        //[InlineData(100000000, 476001412898167)] //10^8, 29 min 36 sec
        public void SolutionForArbitraryInputUsingSieve_TestExample_ReturnsResult(long n, long value)
        {
            var result = Problem642.SolutionForArbitraryInputUsingSieve(n);
            Assert.Equal(value, result);
        }
        
        [Fact]
        public void NEW()
        {
            var result = Problem642.SolutionForArbitraryInputUsingSieve(10);
            Assert.Equal(32, result);
        }
        
        [Fact] //
        public void SolutionForProblem642_ReturnsResult()
        {
            var result = Problem642.Solution();
            //var value = 32;
            Assert.Equal(32, result);
        }
    }
}