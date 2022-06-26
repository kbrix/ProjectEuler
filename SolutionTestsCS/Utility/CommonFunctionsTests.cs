using System.Collections.Generic;
using System.Numerics;
using SolutionCS.Utility;
using NUnit.Framework;

namespace SolutionTestsCS.UtilityTests
{
    public class CommonFunctionsTests
    {
        private static IEnumerable<TestCaseData> Factorial_NaturalNumber_Data
        {
            get
            {
                yield return new TestCaseData((BigInteger) 1, (BigInteger) 1);
                yield return new TestCaseData((BigInteger) 2, (BigInteger) 2);
                yield return new TestCaseData((BigInteger) 3, (BigInteger) 6);
                yield return new TestCaseData((BigInteger) 4, (BigInteger) 24);
                yield return new TestCaseData((BigInteger) 5, (BigInteger) 120);
                yield return new TestCaseData((BigInteger) 6, (BigInteger) 720);
                yield return new TestCaseData((BigInteger) 7, (BigInteger) 5040);
                yield return new TestCaseData((BigInteger) 8, (BigInteger) 40320);
                yield return new TestCaseData((BigInteger) 9, (BigInteger) 362880);
                yield return new TestCaseData((BigInteger) 10, (BigInteger) 3628800);
                yield return new TestCaseData((BigInteger) 20, (BigInteger) 2432902008176640000);
            }
        }

        [Test, TestCaseSource(nameof(Factorial_NaturalNumber_Data))]
        public void Factorial_NaturalNumber_ReturnsResult(BigInteger n, BigInteger x)
        {
            Assert.AreEqual((BigInteger)1, ((BigInteger)1).Factorial());
        }

        [Test]
        public void BinomialCoefficient_PairsOfNaturalNumbers_ReturnsResult()
        {
            var value = new BigInteger[,]
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 3, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 4, 6, 4, 1, 0, 0, 0, 0, 0, 0 },
                { 5, 10, 10, 5, 1, 0, 0, 0, 0, 0 },
                { 6, 15, 20, 15, 6, 1, 0, 0, 0, 0 },
                { 7, 21, 35, 35, 21, 7, 1, 0, 0, 0 },
                { 8, 28, 56, 70, 56, 28, 8, 1, 0, 0 },
                { 9, 36, 84, 126, 126, 84, 36, 9, 1, 0 },
                { 10, 45, 120, 210, 252, 210, 120, 45, 10, 1 },
            };
            
            var result = new BigInteger[10, 10];
            
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    result[i, j] = CommonFunctions.BinomialCoefficient(i + 1, j + 1);
                }
            }
            
            Assert.AreEqual(value, result);
        }
    }
}