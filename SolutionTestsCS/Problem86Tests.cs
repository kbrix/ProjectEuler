using System;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS;

public class Problem86Tests
{
    [Test]
    public void ReturnsExample1()
    {
        var result = Problem86.Solution(maximumLengthSize: 99, maximumIntegerShortestPathCount: int.MaxValue);
        Console.WriteLine(result);
        Assert.That(result.MaximumLegthSize, Is.EqualTo(99));
        Assert.That(result.IntegerShortestPathCount, Is.EqualTo(1975));
    }
    
    [Test]
    public void ReturnsExample2()
    {
        var result = Problem86.Solution(maximumLengthSize: 100, maximumIntegerShortestPathCount: int.MaxValue);
        Console.WriteLine(result);
        Assert.That(result.MaximumLegthSize, Is.EqualTo(100));
        Assert.That(result.IntegerShortestPathCount, Is.EqualTo(2060));
    }
    
    [Test]
    public void ReturnsExample2WithUnboundedLength()
    {
        var result = Problem86.Solution(maximumLengthSize: int.MaxValue, maximumIntegerShortestPathCount: 2000);
        Console.WriteLine(result);
        Assert.That(result.MaximumLegthSize, Is.EqualTo(100));
    }
    
    [Test]
    public void ReturnsSolution()
    {
        var result = Problem86.Solution(maximumLengthSize: int.MaxValue, maximumIntegerShortestPathCount: 1_000_000);
        Console.WriteLine(result);
        Assert.That(result.MaximumLegthSize, Is.EqualTo(1818));
    }
}