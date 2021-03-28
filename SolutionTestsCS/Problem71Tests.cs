using System.Collections.Generic;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS
{
    class Problem71Tests
    {
        private static IEnumerable<TestCaseData> FarleySequence_Int_Data
        {
            get
            {
                yield return new TestCaseData(1, new List<(int numerator, int denominator)> { (0, 1), (1, 1) });
                yield return new TestCaseData(2, new List<(int numerator, int denominator)> { (0, 1), (1, 2), (1, 1) });
                yield return new TestCaseData(3, new List<(int numerator, int denominator)> { (0, 1), (1, 3), (1, 2), (2, 3), (1, 1) });
                yield return new TestCaseData(4, new List<(int numerator, int denominator)> { (0, 1), (1, 4), (1, 3), (1, 2), (2, 3), (3, 4), (1, 1) });
            }
        }

        [Test, TestCaseSource(nameof(FarleySequence_Int_Data))]
        public static void FarLeySequence_Int_ReturnsSequence(int n, List<(int numerator, int denominator)> sequence)
        {
            var result = Problem71.FarleySequence(n);
            CollectionAssert.AreEqual(sequence, result);
        }

        [Test]
        public void GetExample()
        {
            var result = Problem71.Solution(8);
            Assert.AreEqual((2, 5), result);
        }

        [Test]
        [Ignore("Too long, takes 14 seconds.")]
        public void GetBigExample()
        {
            var result = Problem71.Solution(100_000);
            Assert.AreEqual((42857, 100000), result);
        }

        [Test]
        [Ignore("Too long, takes 23 minutes!")]
        public void GetSolution()
        {
            var result = Problem71.Solution(1_000_000);
            Assert.AreEqual((428_570, 999_997), result);
        }
    }
}
