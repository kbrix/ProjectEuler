﻿using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace SolutionTestsCS;

public class Problem65Tests
{
    [TestCase(1, 2)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 1)]
    [TestCase(5, 1)]
    [TestCase(6, 4)]
    [TestCase(7, 1)]
    [TestCase(8, 1)]
    [TestCase(9, 6)]
    [TestCase(10, 1)]
    [TestCase(11, 1)]
    [TestCase(12, 8)]
    [TestCase(13, 1)]
    [TestCase(14, 1)]
    [TestCase(15, 10)]
    [TestCase(16, 1)]
    [TestCase(17, 1)]
    [TestCase(18, 12)]
    [TestCase(19, 1)]
    [TestCase(20, 1)]
    [TestCase(21, 14)]
    [TestCase(22, 1)]
    [TestCase(23, 1)]
    [TestCase(24, 16)]
    [TestCase(25, 1)]
    [TestCase(26, 1)]
    [TestCase(27, 18)]
    [TestCase(28, 1)]
    [TestCase(29, 1)]
    [TestCase(30, 20)]
    [TestCase(31, 1)]
    [TestCase(32, 1)]
    [TestCase(33, 22)]
    [TestCase(34, 1)]
    [TestCase(35, 1)]
    [TestCase(36, 24)]
    [TestCase(37, 1)]
    [TestCase(38, 1)]
    [TestCase(39, 26)]
    [TestCase(40, 1)]
    [TestCase(41, 1)]
    [TestCase(42, 28)]
    [TestCase(43, 1)]
    [TestCase(44, 1)]
    [TestCase(45, 30)]
    [TestCase(46, 1)]
    [TestCase(47, 1)]
    [TestCase(48, 32)]
    [TestCase(49, 1)]
    [TestCase(50, 1)]
    [TestCase(51, 34)]
    [TestCase(52, 1)]
    [TestCase(53, 1)]
    [TestCase(54, 36)]
    [TestCase(55, 1)]
    [TestCase(56, 1)]
    [TestCase(57, 38)]
    [TestCase(58, 1)]
    [TestCase(59, 1)]
    [TestCase(60, 40)]
    [TestCase(61, 1)]
    [TestCase(62, 1)]
    [TestCase(63, 42)]
    [TestCase(64, 1)]
    [TestCase(65, 1)]
    [TestCase(66, 44)]
    [TestCase(67, 1)]
    [TestCase(68, 1)]
    [TestCase(69, 46)]
    [TestCase(70, 1)]
    [TestCase(71, 1)]
    [TestCase(72, 48)]
    [TestCase(73, 1)]
    [TestCase(74, 1)]
    [TestCase(75, 50)]
    [TestCase(76, 1)]
    [TestCase(77, 1)]
    [TestCase(78, 52)]
    [TestCase(79, 1)]
    [TestCase(80, 1)]
    [TestCase(81, 54)]
    [TestCase(82, 1)]
    [TestCase(83, 1)]
    [TestCase(84, 56)]
    [TestCase(85, 1)]
    [TestCase(86, 1)]
    [TestCase(87, 58)]
    [TestCase(88, 1)]
    [TestCase(89, 1)]
    [TestCase(90, 60)]
    [TestCase(91, 1)]
    [TestCase(92, 1)]
    [TestCase(93, 62)]
    [TestCase(94, 1)]
    [TestCase(95, 1)]
    [TestCase(96, 64)]
    [TestCase(97, 1)]
    [TestCase(98, 1)]
    [TestCase(99, 66)]
    public static void CanonicalContinuedFractionExpansionForE_Test(int n, int expectedValue)
    {
        var actualValue = SolutionCS.Problem65.CanonicalContinuedFractionExpansionForE(n);
        Assert.AreEqual(expectedValue, actualValue);
    }

    [Test]
    public static void ExampleTest()
    {
        var a = Enumerable.Range(1, 10)
            .Select(SolutionCS.Problem65.CanonicalContinuedFractionExpansionForE)
            .ToArray();
        var (numerator, denominator) = SolutionCS.Problem65.ContinuedFractionConvergents(a);
        CollectionAssert.AreEqual(new BigInteger[]{ 2, 3, 8, 11, 19, 87, 106, 193, 1264, 1457 }, numerator);
        CollectionAssert.AreEqual(new BigInteger[] { 1, 1, 3, 4, 7, 32, 39, 71, 465, 536 }, denominator);
    }

    [Test]
    public static void SolutionTest()
    {
        Assert.AreEqual(272, SolutionCS.Problem65.Solution());
    }
}