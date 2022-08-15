using System.Linq;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS;

public static class Problem80Tests
{
    [Test]
    public static void Example_ReturnsDigits_OtherMethod()
    {
        var (wholePart, digits) = Problem80.GetDecimalExpansionForSquareRoot(2, 500, 99);
        var digitList = digits.ToList();
        Assert.AreEqual(99, digitList.Count);
        Assert.AreEqual(475, wholePart + digitList.Sum());
    }
    
    [Test]
    public static void Example_ReturnsDigits()
    {
        var expectedDigits = new[] { 1 /*whole number*/, 4, 1, 4, 2, 1, 3, 5, 6, 2, 3, 7, 3, 0, 9, 5, 0, 4, 8, 8, 0 };
        var digits = Problem80.FrazerJarvisSquareRootDigits(2, 20 + 1);
        CollectionAssert.AreEqual(expectedDigits, digits);
    }

    [Test]
    public static void Example_ReturnsDigitSum_2()
    {
        var digits = Problem80.FrazerJarvisSquareRootDigits(2, 100).ToList();
        Assert.AreEqual(100, digits.Count);
        Assert.AreEqual(475, digits.Sum());
    }
    
    [Test]
    public static void Example_ReturnsDigitSum_3()
    {
        var digits = Problem80.FrazerJarvisSquareRootDigits(3, 100).ToList();
        Assert.AreEqual(100, digits.Count);
        Assert.AreEqual(441, digits.Sum());
    }

    [Test]
    public static void SolutionTest()
    {
        Assert.AreEqual(40886, Problem80.Solution(100));
    }
    
    [Test]
    public static void SolutionTestExtra()
    {
        Assert.AreEqual(405_200, Problem80.Solution(1_000));
        // Assert.AreEqual(4_048_597, Problem80.Solution(10_000)); // ~8 minutes 25 seconds
        // Assert.AreEqual(40_498_748 , Problem80.Solution(100_000)); // ???
    }
}