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
    
    /// <summary>
    /// Given canonical continued fraction expansion values, returns the numerators and denominators in the continued
    /// fraction convergents. See G. H. Hardy and E. M. Wright, An Introduction to the Theory of Numbers, 6th ed.,
    /// Oxford University Press, Oxford, 1979, Theorem 149, section 10.2, page 166.
    /// </summary>
    /// <param name="a">Canonical continued fraction expansion values.</param>
    /// <returns>The numerators and denominators in the continued fraction convergents.</returns>
    public static (BigInteger[] p, BigInteger[] q) ContinuedFractionConvergents(int[] a)
    {
        var p = new BigInteger[a.Length];
        var q = new BigInteger[a.Length];

        p[0] = a[0];
        p[1] = a[0] * a[1] + 1;

        q[0] = 1;
        q[1] = a[1];

        for (var n = 2; n < a.Length; n++)
        {
            p[n] = a[n] * p[n - 1] + p[n - 2];
            q[n] = a[n] * q[n - 1] + q[n - 2];
        }
        
        return (p, q);
    }
    
    public static int Solution()
    {
        var a = Enumerable.Range(1, 100)
            .Select(CanonicalContinuedFractionExpansionForE)
            .ToArray();
        
        var (numerator, denominator) = ContinuedFractionConvergents(a);
        
        Console.WriteLine($"Numerator: '{numerator.Last()}'.");
        Console.WriteLine($"Denominator: '{denominator.Last()}'.");
        
        return numerator.Last().DigitSum();
    }
}