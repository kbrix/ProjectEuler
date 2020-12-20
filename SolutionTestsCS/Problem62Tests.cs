using System.Numerics;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem62Tests
    {
        [Test]
        public static void GetExample()
        {
            Assert.AreEqual((BigInteger) 41063625, Problem62.Solution(3));
        }

        [Test]
        public static void GetExtra_Ohhho_Aaahh()
        {
            Assert.AreEqual(BigInteger.Pow(1002, 3), Problem62.Solution(4));
        }

        [Test]
        public static void GetSolution()
        {
            Assert.AreEqual(BigInteger.Pow(5027, 3), Problem62.Solution(5));
        }
    }
}
