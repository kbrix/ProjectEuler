using System;

namespace euler.Utility
{
    public class Miscellaneous
    {
        /// <summary>
        /// Converts a latin character to the corresponding letter's index in the standard Latin alphabet
        /// </summary>
        /// <param name="letter">An upper- or lower-case Latin character</param>
        /// <returns>Returns alphabetical position, starting at one, of the letter in the Latin alphabet</returns>
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
    }
}