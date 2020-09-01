using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem642Tests
    {
        
        [TestCase(10, 32)] // 10^1
        [TestCase(100, 1915)] // 10^2
        [TestCase(10000, 10118280)] //10^4
        [TestCase(100000, 793111753)] //10^5
        [TestCase(1000000, 64937323262)] //10^6, 2.5 sec
        //[TestCase(10000000, 5494366736156)] //10^7, 1 min 4 sec
        //[TestCase(100000000, 476001412898167)] //10^8, 28 min 58 sec
        public void SolutionForArbitraryInput_TestExample_ReturnsResult(long n, long value)
        {
            var result = Problem642.SolutionForArbitraryInput(n);
            Assert.AreEqual(value, result);
        }
        
        // 201820182018 = 2.0182e+11
        
        [TestCase(10, 32)] // 10^1
        [TestCase(100, 1915)] // 10^2
        [TestCase(10000, 10118280)] //10^4
        [TestCase(100000, 793111753)] //10^5
        [TestCase(1000000, 64937323262)] //10^6, 2.5 sec
        //[TestCase(10000000, 5494366736156)] //10^7, 1 min 6 sec
        //[TestCase(100000000, 476001412898167)] //10^8, 29 min 36 sec
        public void SolutionForArbitraryInputUsingSieve_TestExample_ReturnsResult(long n, long value)
        {
            var result = Problem642.SolutionForArbitraryInputUsingSieve(n);
            Assert.AreEqual(value, result);
        }
        
        [Test]
        public void NEW()
        {
            var result = Problem642.SolutionForArbitraryInputUsingSieve(10);
            Assert.AreEqual(32, result);
        }
        
        //[Test] //
        //public void SolutionForProblem642_ReturnsResult()
        //{
        //    var result = Problem642.Solution();
        //    //var value = 32;
        //    Assert.AreEqual(32, result);
        //}
    }
}