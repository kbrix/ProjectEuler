using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    public class Problem64Tests
    {
        [TestCase(2, new[] { 1, 2 })]
        [TestCase(3, new[] { 1, 1, 2 })]
        [TestCase(5, new[] { 2, 4 })]
        [TestCase(6, new[] { 2, 2, 4 })]
        [TestCase(7, new[] { 2, 1, 1, 1, 4 })]
        [TestCase(8, new[] { 2, 1, 4 })]
        [TestCase(10, new[] { 3, 6 })]
        [TestCase(11, new[] { 3, 3, 6 })]
        [TestCase(12, new[] { 3, 2, 6 })]
        [TestCase(13, new[] { 3, 1, 1, 1, 1, 6 })]
        [TestCase(23, new[] { 4, 1, 3, 1, 8 })]
        [TestCase(114, new[] { 10, 1, 2, 10, 2, 1, 20 })]
        public void GetPeriodicContinuedFractionSequenceTest_ReturnsSequence(int number, int[] expectedSequence)
        {
            var actualSequence = Problem64.GetPeriodicContinuedFractionSequence(number).ToArray();
            CollectionAssert.AreEqual(expectedSequence, actualSequence);
        }

        [TestCase(1)]
        [TestCase(9)]
        public void GetPeriodicContinuedFractionSequenceTest_ThrowsError(int number)
        {
            TestDelegate method = () => Problem64.GetPeriodicContinuedFractionSequence(number);
            Assert.Throws<ArgumentOutOfRangeException>(method);
        }

        [Test]
        public void GetSolution()
        {
            Assert.AreEqual(1322, Problem64.Solution());
        }
    }
}
