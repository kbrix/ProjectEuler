using SolutionCS.Utility;
using NUnit.Framework;

namespace SolutionTestsCS.UtilityTests
{
    public class MiscellaneousTests
    {
        [TestCase('A', 1)]
        [TestCase('B', 2)]
        [TestCase('C', 3)]
        [TestCase('D', 4)]
        [TestCase('E', 5)]
        [TestCase('F', 6)]
        [TestCase('G', 7)]
        [TestCase('H', 8)]
        [TestCase('I', 9)]
        [TestCase('J', 10)]
        [TestCase('K', 11)]
        [TestCase('L', 12)]
        [TestCase('M', 13)]
        [TestCase('N', 14)]
        [TestCase('O', 15)]
        [TestCase('P', 16)]
        [TestCase('Q', 17)]
        [TestCase('R', 18)]
        [TestCase('S', 19)]
        [TestCase('T', 20)]
        [TestCase('U', 21)]
        [TestCase('V', 22)]
        [TestCase('W', 23)]
        [TestCase('X', 24)]
        [TestCase('Y', 25)]
        [TestCase('Z', 26)]
        public void ConvertLetterToNumber_Letter_ReturnsAlphabeticalPosition(char x, int y)
        {
            var result = Miscellaneous.ConvertLetterToNumber(x);
            Assert.AreEqual(y, result);
        }

        [TestCase(23, 1, 5)]
        [TestCase(60, 1, 6)]
        [TestCase(64, 1, 10)]
        [TestCase(1111, 1, 4)]
        [TestCase(1000000001, 1, 2)]
        [TestCase(121, 5, 34)]
        public void DigitSum_Number_ReturnsDigitSum(int x, int p, int a)
        {
            var result = x.DigitSum(p);
            Assert.AreEqual(a, result);
        }

        [TestCase(87109, 79180, true)]
        [TestCase(8951223, 5544864, false)]
        public void IsPermutationOf_Numbers_ReturnsBoolean(int x, int y, bool b)
        {
            var result = x.IsPermutationOf(y);
            Assert.AreEqual(b, result);
        }

        [TestCase(3797, 0, 3797)]
        [TestCase(3797, 1, 797)]
        [TestCase(3797, 2, 97)]
        [TestCase(3797, 3, 7)]
        public void TruncateLeftToRight_Number_ReturnsTruncatedNumber(int number, int step, int result)
        {
            Assert.AreEqual(result, number.TruncateLeftToRight(step));
        }

        [TestCase(3797, 0, 3797)]
        [TestCase(3797, 1, 379)]
        [TestCase(3797, 2, 37)]
        [TestCase(3797, 3, 3)]
        public void TruncateRightToLeft_Number_ReturnsTruncatedNumber(int number, int step, int result)
        {
            Assert.AreEqual(result, number.TruncateRightToLeft(step));
        }
    }
}