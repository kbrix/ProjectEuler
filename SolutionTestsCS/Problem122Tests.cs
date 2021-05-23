using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem122Tests
    {
        [Test]
        public static void ReturnExample()
        {
            var chains = Problem122.GetAdditiveChains(15);
            var chains15 = chains[15];
            var minimumChainLength = chains15
                .Select(chain => chain.Length - 1)
                .Min();
            Assert.AreEqual(5, minimumChainLength);
        }
        
        [Test]
        public static void ReturnAnotherExample()
        {
            var chains = Problem122.GetAdditiveChains(154);
            var chains154 = chains[154];
            var minimumChainLength = chains154
                .Select(chain => chain.Length - 1)
                .Min();
            Assert.AreEqual(9, minimumChainLength);
        }
        
        [Test]
        public static void ReturnsSolution()
        {
            var solution = Problem122.Solution();
            Assert.AreEqual(1582, solution);
        }
    }
}