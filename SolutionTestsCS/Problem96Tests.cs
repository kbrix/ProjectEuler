using System;
using NUnit.Framework;
using SolutionCS;

namespace SolutionTestsCS;

public class Problem96Tests
{
    [Test]
    public static void ExampleFromProjectEuler()
    {
        var example =
            """
            003020600
            900305001
            001806400
            008102900
            700000008
            006708200
            002609500
            800203009
            005010300
            """;
        var expectedSolution =
            """
            483921657
            967345821
            251876493
            548132976
            729564138
            136798245
            372689514
            814253769
            695417382
            """;

        var expectedGrid = Problem96.CreateGridFromString(expectedSolution);
        
        var exampleGrid = Problem96.CreateGridFromString(example);
        var solutionGrid = Problem96.SolveSuDoku(exampleGrid);
        
        Assert.AreEqual(expectedGrid, solutionGrid);
        Console.WriteLine(Problem96.CreateStringFromGrid(solutionGrid));
    }

    [Test]
    public static void ExampleFromWikipedia()
    {
        var example =
            """
            530070000
            600195000
            098000060
            800060003
            400803001
            700020006
            060000280
            000419005
            000080079
            """;
        var expectedSolution =
            """
            534678912
            672195348
            198342567
            859761423
            426853791
            713924856
            961537284
            287419635
            345286179
            """;

        var expectedGrid = Problem96.CreateGridFromString(expectedSolution);
        
        var exampleGrid = Problem96.CreateGridFromString(example);
        var solutionGrid = Problem96.SolveSuDoku(exampleGrid);
        
        Assert.AreEqual(expectedGrid, solutionGrid);
        Console.WriteLine(Problem96.CreateStringFromGrid(solutionGrid));
    }

    [Test]
    public static void Solution()
    {
        var solution = Problem96.Solution();
        Assert.AreEqual(24702, solution);
    }
}