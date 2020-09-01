using SolutionCS;
using NUnit.Framework;

namespace SolutionTestsCS
{
    public class Problem44Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            var result = Problem44.Solution(); // pentagonNumber[2167] = 7042750, pentagonNumber[1020] = 1560090
            Assert.AreEqual(5482660, result);
        }
    }
}
