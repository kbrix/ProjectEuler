using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem28Tests
    {
        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        [TestCase(3, 7)]
        [TestCase(4, 9)]
        [TestCase(5, 13)]
        [TestCase(6, 17)]
        [TestCase(7, 21)]
        [TestCase(8, 25)]
        [TestCase(9, 31)]
        [TestCase(10, 37)]
        [TestCase(11, 43)]
        [TestCase(12, 49)]
        [TestCase(13, 57)]
        [TestCase(14, 65)]
        [TestCase(15, 73)]
        [TestCase(16, 81)]
        public static void SpiralDiagonalSequence_(int n, int x)
        {
            var element = Problem28.SpiralDiagonalSequence(n);
            Assert.AreEqual(x, element);
        }

        [TestCase(5, 101)]
        [TestCase(1001, 669171001)]
        public static void ReturnsSolution(int n, int x)
        {
            var result = Problem28.Solution(n);
            Assert.AreEqual(x, result);
        }
    }
}
