using System;

namespace SolutionCS;

/// <summary>
/// Cuboid Route: https://projecteuler.net/problem=86.
/// </summary>
public class Problem86
{
    private static double ShortestPath(int a, int b, int c) => Math.Sqrt(a * a + (b + c) * (b + c));
    
    public static (int MaximumLegthSize, int IntegerShortestPathCount) Solution(
        int maximumLengthSize, int maximumIntegerShortestPathCount)
    {
        var count = 0;
        
        // The inequalities implicitly assume that M >= a >= b >= c >= 1 for which the shortest path is given above.
        for (int a = 1; a <= maximumLengthSize; a++)
        for (int b = 1; b <= a; b++)
        for (int c = 1; c <= b; c++)
        {
            var shortestPath = ShortestPath(a, b, c);

            if (double.IsInteger(shortestPath))
                count++;

            if (count > maximumIntegerShortestPathCount)
                return (MaximumLegthSize: a, IntegerShortestPathCount: count);
        }

        return (MaximumLegthSize: maximumLengthSize, IntegerShortestPathCount: count);
    }
}