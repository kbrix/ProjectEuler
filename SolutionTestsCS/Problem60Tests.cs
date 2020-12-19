using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SolutionCS;
using SolutionCS.Utility;

namespace SolutionTestsCS
{
    class Problem60Tests
    {
        [Test]
        public static void ReturnsExample()
        {
            Assert.AreEqual(792, Problem60.Solution(4, 700));
        }

        [Test]
        public static void ReturnsSolution()
        {
            Assert.AreEqual(26033, Problem60.Solution(5, 8389)); // 13, 5197, 6733, 8389
        }
    }
}
