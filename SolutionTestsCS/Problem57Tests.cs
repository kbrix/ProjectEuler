using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rationals;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem57Tests
    {
        [TestCase(1, 3, 2)]
        [TestCase(2, 7, 5)]
        [TestCase(3, 17, 12)]
        [TestCase(4, 41, 29)]
        [TestCase(5, 99, 70)]
        [TestCase(6, 239, 169)]
        [TestCase(7, 577, 408)]
        [TestCase(8, 1393, 985)]
        public void ContinuedFraction_Examples_ReturnsResult(int n, int numerator, int denominator)
        {
            var expectedFraction = new Rational(numerator, denominator);
            var actualFraction = Problem57.ContinuedFraction(n);
            Assert.True(expectedFraction == actualFraction);
        }

        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(153, Problem57.Solution());
        }
    }
}
