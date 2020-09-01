using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem26Tests
    {
        
        [TestCase(7, 6)]
        [TestCase(17, 16)]
        [TestCase(19, 18)]
        [TestCase(23, 22)]
        [TestCase(29, 28)]
        [TestCase(47, 46)]
        [TestCase(59, 58)]
        [TestCase(61, 60)]
        [TestCase(97, 96)]
        [TestCase(983, 982)]
        public static void RepeatingDigitCount_Number_ReturnsNumberOfRepeatingDigits(int n, int digitCount)
        {
            var result = Problem26.RepeatingDigitCount(n);
            Assert.AreEqual(digitCount, result);
        }

        [Test]
        public static void Solution_ReturnsResult()
        {
            var result = Problem26.Solution(1000);
            Assert.AreEqual(983, result);
        }
    }
}
