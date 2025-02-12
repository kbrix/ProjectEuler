using System;

namespace SolutionCS;

/// <summary>
/// Right Triangles with Integer Coordinates, https://projecteuler.net/problem=91
/// </summary>
public static class Problem91
{
    public static int Example()
    {
        return Solution(2);
    }
    
    public static int Solution(int max)
    {
        var counter = 0;
        // A
        var x1 = 0;
        var y1 = 0;
        // B
        for (var x2 = 0; x2 <= max; x2++)
        for (var y2 = 0; y2 <= max; y2++)
        // C
        for (var x3 = 0; x3 <= max; x3++)
        for (var y3 = 0; y3 <= max; y3++)
        {
            // For uniqueness, to ensure that (x2, y2) has a larger angle than (x3, y3)
            if (y3 * x2 >= y2 * x3) 
                break;
            
            var ab = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            var bc = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            var ca = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));

            if (IsRightAngleTriangle(ab, bc, ca))
                counter++;
        }

        return counter;
    }
    
    private static bool IsRightAngleTriangle(double a, double b, double c)
    {
        const double tolerance = 1e-6;
        return Math.Abs(a * a + b * b - c * c) < tolerance 
               || Math.Abs(b * b + c * c - a * a) < tolerance
               || Math.Abs(c * c + a * a - b * b) < tolerance;
    }
}