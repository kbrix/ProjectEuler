using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SolutionCS.Utility
{
    public static class Miscellaneous
    {
        /// <summary>
        /// Converts a latin character to the corresponding letter's index in the standard Latin alphabet.
        /// </summary>
        /// <param name="letter">An upper- or lower-case Latin character.</param>
        /// <returns>Returns alphabetical position, starting at one, of the letter in the Latin alphabet.</returns>
        public static int ConvertLetterToNumber(char letter)
        {
            // Uses the uppercase character unicode code point. 'A' = U+0042 = 65, 'Z' = U+005A = 90
            var x = char.ToUpper(letter);
            if (x < 'A' || x > 'Z')
            {
                throw new ArgumentOutOfRangeException(nameof(letter), "This method only accepts standard Latin characters.");
            }

            return x - 'A' + 1;
        }

        /// <summary>
        /// Convert a word consisting of Latin characters into a number by summing each letter's index value.
        /// </summary>
        /// <param name="word">A word consisting of Latin characters.</param>
        /// <returns>Returns the sum letter values, see also 'ConvertLetterToNumber()'.</returns>
        public static int ConvertWordToNumber(string word)
        {
            return word.ToCharArray().Sum(ConvertLetterToNumber);
        }

        public static IEnumerable<int> Digits(this int x)
        {
            return x.ToString().Select(n => (int) char.GetNumericValue(n));
        }

        public static IEnumerable<BigInteger> Digits(this BigInteger x)
        {
            return x.ToString().Select(n => (BigInteger) char.GetNumericValue(n));
        }

        public static int DigitSum(this int x)
        {
            return x.Digits().Sum();
        }

        /// <summary>
        /// Computes the digit sum in base 10.
        /// </summary>
        /// <param name="x">A natural number.</param>
        /// <returns>The digit sum.</returns>
        public static int DigitSum(this int x, int p)
        {
            if (x == 0)
            {
                return 0;
            }

            var sum = 0d;

            var max = (int)Math.Floor(Math.Log10(x));

            for (int n = 0; n <= max; n++)
            {
                sum += Math.Pow(1 / Math.Pow(10, n) * ( x % Math.Pow(10, n + 1) - x % Math.Pow(10, n) ), p);
            }

            return (int)sum;
        }

        /// <summary>
        /// Computes the digit sum (using string conversion).
        /// </summary>
        /// <param name="x">A natural number.</param>
        /// <returns>The digit sum.</returns>
        public static int DigitSum(this BigInteger x)
        {
            return (int) x.ToString().Sum(char.GetNumericValue);
        }

        /// <summary>
        /// Returns the number of digits.
        /// </summary>
        /// <param name="x">A natural number.</param>
        /// <returns>The number of digits.</returns>
        public static int DigitLength(this int x)
        {
            return x.ToString().Length;
        }

        public static int DigitLength(this long x)
        {
            return x.ToString().Length;
        }

        public static int DigitLength(this BigInteger x)
        {
            return x.ToString().Length;
        }

        public static bool IsPermutationOf<T>(this T x, T y)
        {
            var a = x.ToString();
            var b = y.ToString();

            if (a.Length != b.Length)
            {
                return false;
            }

            var aDesc = new string(a.OrderByDescending(s => s).ToArray());
            var bDesc = new string(b.OrderByDescending(s => s).ToArray());
            return aDesc == bDesc;
        }

        /// <summary>
        /// Truncates number from left to right.
        /// </summary>
        /// <param name="number">The number to truncate.</param>
        /// <param name="step">Number of digits to truncate.</param>
        /// <returns></returns>
        public static int TruncateLeftToRight(this int number, int step)
        {
            if (step == 0)
            {
                return number;
            }
            var digits = number.GetDigits();
            if (!(step <= digits.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(step));
            }
            digits.RemoveRange(0, step);
            return digits.ConcatenateDigits();
        }

        /// <summary>
        /// Truncates number from right to left.
        /// </summary>
        /// <param name="number">The number to truncate.</param>
        /// <param name="step">Number of digits to truncate.</param>
        /// <returns></returns>
        public static int TruncateRightToLeft(this int number, int step)
        {
            if (step == 0)
            {
                return number;
            }
            var digits = number.GetDigits();
            if (!(step <= digits.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(step));
            }
            digits.RemoveRange(digits.Count - step, step);
            return digits.ConcatenateDigits();
        }

        /// <summary>
        /// Checks if an n-digit number is pandigital (uses all digits from 1 to n exactly once, e.g. 7652413 is pandigital).
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static bool IsPandigital(this List<int> digits)
        {
            return !digits.Contains(0) && digits.Count == 9 && digits.Distinct().Count() == 9;
        }

        public static bool IsPandigital(this int n)
        {
            var digits = n.GetDigits();
            return !digits.Contains(0) && digits.Count == 9 && digits.Distinct().Count() == 9;
        }

        public static bool IsPandigital(this long n)
        {
            var digits = n.GetDigits();
            return !digits.Contains(0) && digits.Count == 9 && digits.Distinct().Count() == 9;
        }

        /// <summary>
        /// Concatenates two numbers.
        /// </summary>
        /// <param name="n">The first number.</param>
        /// <param name="m">The second number.</param>
        /// <returns>The concatenated number.</returns>
        public static int Concatenate(this int n, int m)
        {
            return int.Parse(n.ToString() + m.ToString());
        }
        
        /// <summary>
        /// Check if a number is a perfect square by checking if the square root is a whole number.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <returns>Is this number a perfect square?</returns>
        public static bool IsPerfectSquare(int n)
        {
            return Math.Abs(Math.Floor(Math.Sqrt(n)) - Math.Sqrt(n)) == 0;
        }

        /// <summary>
        /// Gets the periodic continued fraction expansion in canonical form for non-prefect squares, sqrt (s).
        /// See the algorithm <seealso href="https://en.wikipedia.org/wiki/Periodic_continued_fraction"/>.
        /// </summary>
        /// <param name="s">A non-prefect square.</param>
        /// <returns>Periodic continued fraction expansion.</returns>
        public static IEnumerable<int> GetPeriodicContinuedFractionSequence(int s)
        {
            if (IsPerfectSquare(s))
                throw new ArgumentOutOfRangeException(nameof(s), "Input cannot be a perfect square.");

            var m = 0;
            var d = 1;
            var a0 = (int)Math.Sqrt(s);
            var a = a0;

            var sequence = new List<int> { a };

            do
            {
                m = d * a - m;
                d = (s - m * m) / d;
                a = (a0 + m) / d;
                sequence.Add(a);
            } while (
                a != 2 * a0
            );

            return sequence;
        }
        
        /// <summary>
        /// Given canonical continued fraction expansion values, returns the numerators and denominators in the continued
        /// fraction convergents. See G. H. Hardy and E. M. Wright, An Introduction to the Theory of Numbers, 6th ed.,
        /// Oxford University Press, Oxford, 1979, Theorem 149, section 10.2, page 166.
        /// </summary>
        /// <remarks>Makes sense to use with <see cref="GetPeriodicContinuedFractionSequence"/>.</remarks>
        /// <param name="source">Canonical continued fraction expansion values.</param>
        /// <returns>The numerators and denominators in the continued fraction convergents.</returns>
        public static IEnumerable<(BigInteger p, BigInteger q)> ContinuedFractionConvergents(IEnumerable<int> source)
        {
            var a = source.ToArray();
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

            var convergents = new List<(BigInteger p, BigInteger q)>();
            for (var i = 0; i < a.Length; i++)
                convergents.Add((p[i], q[i]));
        
            return convergents;
        }
    }
}