using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS;

public class Problem66
{
    /// <summary>
    /// Finds the fundamental solution to Pell's equation of the form x^2 - n * y^2 = 1, where n is not a perfect square.
    /// </summary>
    /// <remarks>See the section on solutions at <see href="https://en.wikipedia.org/wiki/Pell%27s_equation"/>.</remarks>
    /// <param name="n">The constant in Pell's equation.</param>
    /// <returns>The fundamental solution (x, y) to Pell's equation.</returns>
    /// <exception cref="ArgumentException">An exception is thrown when no solution is found, i.e. when the sequence
    /// of canonical periodic fraction expansion values are not sufficiently repeated.</exception>
    public static (BigInteger x, BigInteger y) FundamentalSolutionForPellsEquation(int n)
    {
        var sequence = Miscellaneous
            .GetPeriodicContinuedFractionSequence(n)
            .AfterFirstRepeatTimes(3)
            .ToList();
        
        var convergents = Miscellaneous
            .ContinuedFractionConvergents(sequence);

        foreach (var (x, y) in convergents)
        {
            if (x * x - n * y * y == BigInteger.One)
                return (x, y);
        }

        throw new ArgumentException("Solution does not exist.", nameof(n));
    }
    
    public static int Solution()
    {
        var fundamentalSolutions = new Dictionary<int, (BigInteger x, BigInteger y)>();
        for (var i = 2; i < 1000; i++)
        {
            if (!Miscellaneous.IsPerfectSquare(i))
                fundamentalSolutions.Add(i, FundamentalSolutionForPellsEquation(i));
        }

        var maxByX = fundamentalSolutions
            .Max(s => s.Value.x);
        var keyByMaxX = fundamentalSolutions
            .First(s => s.Value.x == maxByX)
            .Key;
        
        Console.WriteLine($"x = {fundamentalSolutions[keyByMaxX].x} and y = {fundamentalSolutions[keyByMaxX].y}");
        return keyByMaxX;
    }
}