using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem58Tests
    {
        [Test]
        public static void ReturnsSolution()
        {
            Assert.AreEqual(26241, Problem58.Solution());
        }
    }
}
