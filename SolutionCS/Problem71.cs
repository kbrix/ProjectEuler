using System;
using System.Collections.Generic;

namespace SolutionCS
{
    public static class Problem71
    {
        // known initial elements a/b, c/d, unknown next element p/q, know last element 1/1
        public static List<(int numerator, int denominator)> FarleySequence(int n, int x = 0, int y = 0)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException();
            
            if (n == 1)
                return new List<(int numerator, int denominator)> { (0, 1),(1, 1) };

            if (n == 2)
                return new List<(int numerator, int denominator)> { (0, 1), (1, 2), (1, 1) };

            if (x == 0 && y == 0)
            {
                x = n - 1;
                y = n;
            }

            var a = 0;
            var b = 1;
            var c = 1;
            var d = n;

            var farleySequence = new List<(int numerator, int denominator)>();
            farleySequence.Add((a, b)); // first term
            farleySequence.Add((c, d)); // second term
            
            do
            {
                var f = (n + b) / d; // implicit floor function
                var p = f * c - a;
                var q = f * d - b;
                farleySequence.Add((p, q));

                a = c;
                b = d;
                c = p;
                d = q;

            } while (!(c == x && d == y)); // c == n-1, d == n

            if (x == n - 1 && y == n)
                farleySequence.Add((1, 1)); // last term

            return farleySequence;
        }

        public static (int numerator, int denominator) Solution(int n, int x = 3, int y = 7)
        {
            var a = 0;
            var b = 1;
            var c = 1;
            var d = n;

            do
            {
                var f = (n + b) / d; // implicit floor function
                var p = f * c - a;
                var q = f * d - b;

                a = c;
                b = d;
                c = p;
                d = q;

            } while (!(c == x && d == y)); // c == n-1, d == n

            return (a, b);
        }
    }
}
