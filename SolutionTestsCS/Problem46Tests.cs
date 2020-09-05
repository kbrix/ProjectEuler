using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SolutionTestsCS
{
    class Problem46Tests
    {
        [TestCase(9, true)]
        [TestCase(15, true)]
        [TestCase(21, true)]
        [TestCase(25, true)]
        [TestCase(27, true)]
        [TestCase(33, true)]
        public void IsSumOfPrimeAndTwiceSquare_Examples_ReturnsResult(int n, bool result)
        {
            Assert.AreEqual(result, SolutionCS.Problem46.IsSumOfPrimeAndTwiceSquare(n));
        }

        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(5777, SolutionCS.Problem46.Solution(10_000));
        }
    }
}
