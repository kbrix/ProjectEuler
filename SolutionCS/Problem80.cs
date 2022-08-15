using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS;

/// <summary>
/// Square root digital expansion.
/// </summary>
public static class Problem80
{
    private static void R1(ref BigInteger a, ref BigInteger b)
    {
        if (a >= b)
        {
            a = a - b;
            b = 10 + b;
        }
    }
    
    private static void R2(ref BigInteger a, ref BigInteger b)
    {
        if (a < b)
        {
            if (b.DigitLength() < 2)
                throw new ArgumentOutOfRangeException(
                    nameof(b), $"The parameter should have more than two digits '{b}'");
            
            a = a * 100;
            b = (b / 10) * 100 + 5;
        }
    }
    
    /// <summary>
    /// Algorithm from From 'Square roots by subtraction' by Frazer Jarvis for computing the digits of a certain length
    /// using digit by digit exactly. Digits include digits to the left and right of the decimal point.
    /// </summary>
    /// <param name="n">The number to find the square root of.</param>
    /// <param name="digits">The numbers of digits to return.</param>
    /// <returns>The digits in the square root.</returns>
    /// <example>
    /// Calling with 'n' = 2 and 'digits' = 21 returns 1, 4, 1, 4, 2, 1, 3, 5, 6, 2, 3, 7, 3, 0, 9, 5, 0, 4, 8, 8, 0.
    /// </example>
    /// <remarks>The reference is found in the literature folder.</remarks>
    public static IEnumerable<int> FrazerJarvisSquareRootDigits(int n, int digits)
    {
        BigInteger limit = BigInteger.Pow(10, digits + 1);
        BigInteger a = 5 * n;
        BigInteger b = 5;

        while (b < limit)
        {
            R1(ref a, ref b);
            R2(ref a, ref b);
        }
        
        return b.Digits().Select(number => (int)number).Take(digits);
    }
    
    public static (int WholePart, IEnumerable<int> Digits) GetDecimalExpansionForSquareRoot(
        int s, int repeatPeriodicFractionSequenceCount, int expansionDigitCount)
    {
        var (p, q) = Miscellaneous
            .GetPeriodicContinuedFractionSequence(s)
            .AfterFirstRepeatTimes(repeatPeriodicFractionSequenceCount)
            .ContinuedFractionConvergents()
            .Last();

        var (wholePart, digits) = Miscellaneous
            .DecimalExpansion(p, q, expansionDigitCount);

        return (wholePart, digits);
    }

    public static int Solution(int digits)
    {
        var sum = 0;
        for (int i = 1; i <= 100; i++)
            if (!Miscellaneous.IsPerfectSquare(i))
                sum += FrazerJarvisSquareRootDigits(i, digits)
                    .Sum(d => d);
        return sum;
    }
}