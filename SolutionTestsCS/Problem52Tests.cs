using System.Numerics;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem52Tests
    {
        [TestCase(125874, 251748, true)]
        [TestCase(123, 124, false)]
        [TestCase(123, 1230, false)]
        [TestCase(100, 101, false)]
        public static void ContainsSameDigits_Numbers_ReturnsBoolean(int x, int y, bool b)
        {
            Assert.AreEqual(Problem52.ContainsSameDigits(x, y), b);
        }

        [Test]
        public static void ContainsSameDigits_Array_ReturnsTrue()
        {
            var array = new BigInteger[] { 1234, 4321, 1243 };
            Assert.True(Problem52.ContainsSameDigits(array));
        }

        [Test]
        public static void ReturnsExample()
        {
            Assert.AreEqual((BigInteger) 142857, Problem52.Solution(200000));
        }

    }
}
