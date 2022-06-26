using System;
using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS;

/// <summary>
/// Convergents of e. See <see href="https://projecteuler.net/problem=65"/>.
/// The continued fraction for e can be found at <see href="http://oeis.org/A003417"/>.
/// </summary>
public static class Problem65
{
    /// <summary>
    /// Function returning the canonical continued fraction expansion value for Euler's constant. These values
    /// are usually denoted a_i, i = 0, 1, 2, ..., but this function is returns a_n, n = 1, 2, 3, ...
    /// Proven in  L. Euler, De fractionibus continuis dissertatio, Comm. Acad. Sci. Petropol. 9 (1744) 98–137;
    /// also in Opera Omnia, ser. I, vol. 14, Teubner, Leipzig, 1925, pp. 187–215; English translation by M. Wyman
    /// and B. Wyman, An essay on continued fractions, Math. Systems Theory 18 (1985) 295–328.
    /// The sequence has the form: 2, 1, 2,   1, 1, 4,   1, 1, 6,   1, 1, 8,   1, 1, 10,   1, 1, 12, ... etc.
    /// </summary>
    /// <param name="n">The index, n = 1, 2, 3, ...</param>
    /// <returns>The indexed canonical continued fraction expansion value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Throw for invalid indices.</exception>
    public static int CanonicalContinuedFractionExpansionForE(int n)
    {
        if (n <= 0)
            throw new ArgumentOutOfRangeException(nameof(n));
        else if (n == 1)
            return 2;
        else if (n == 2)
            return 1;
        else if (n % 3 == 0)
            return 2 * n / 3;
        else
            return 1;
    }

    public static int Solution()
    {
        var a = Enumerable.Range(1, 100)
            .Select(CanonicalContinuedFractionExpansionForE)
            .ToArray();
        
        var convergents = Miscellaneous.ContinuedFractionConvergents(a).ToList();
        
        Console.WriteLine($"Numerator: '{convergents.Last().p}'.");
        Console.WriteLine($"Denominator: '{convergents.Last().q}'.");
        
        return convergents.Last().p.DigitSum();
    }
}