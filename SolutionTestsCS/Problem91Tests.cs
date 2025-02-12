using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS;

public class Problem91Tests
{
    [Test]
    public static void Example()
    {
        var example = Problem91.Example();
        Assert.That(example, Is.EqualTo(14));
    }
    
    [Test]
    public static void Solution()
    {
        var example = Problem91.Solution(50);
        Assert.That(example, Is.EqualTo(14234));
    }
}