using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SolutionCS;
using SolutionCS.Utility;

namespace SolutionTestsCS
{
    class Problem51Tests
    {
        [TestCase(13, new[] { true, false }, new[] { 13, 23, 33, 43, 53, 63, 73, 83, 93 })]
        [TestCase(13, new[] { false, true }, new[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(56993, new[] { false, false, true, true, false }, new[] { 56003, 56113, 56223, 56333, 56443, 56553, 56663, 56773, 56883, 56993 })]
        public void DigitReplacementFamily_TwoDigitCombination_ReturnsFamily(int number, bool[] combination, int[] expected)
        {
            var numberFamily = Problem51.DigitReplacementFamily(number, combination);
            CollectionAssert.AreEquivalent(expected, numberFamily);
        }

        [Test]
        public void ReturnsExample()
        {
            Assert.AreEqual(56003, Problem51.GeneralizedSolution(7, 60000));
        }

        [Test]
        public void ReturnsSolution()
        {
            Assert.AreEqual(121313, Problem51.Solution());
        }

    }
}
