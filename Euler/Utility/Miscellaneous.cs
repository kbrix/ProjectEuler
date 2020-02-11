using System;
using System.Linq;

namespace euler.Utility
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

        /// <summary>
        /// Computes the digit sum in base 10.
        /// </summary>
        /// <param name="x">A natural number.</param>
        /// <returns>The digit sum.</returns>
        public static int DigitSum(this int x, int p = 1)
        {
            var sum = 0d;

            var max = (int)Math.Floor(Math.Log10(x));

            for (int n = 0; n <= max; n++)
            {
                sum += Math.Pow(1 / Math.Pow(10, n) * ( x % Math.Pow(10, n + 1) - x % Math.Pow(10, n) ), p);
            }

            return (int)sum;
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
    }
}