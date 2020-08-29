using System.IO;
using System.Linq;
using euler.Utility;

namespace euler
{
    // Names scores
    // https://projecteuler.net/problem=22
    public static class Problem22
    {
        public static int Solution()
        {
            var names = File.ReadAllLines("../../../20-29/p022_names.txt"); // cleaned and ordered beforehand
            var values = new int[names.Length];
            
            for (int i = 0; i < names.Length; i++)
            {
                var letters = names[i].ToCharArray();
                var score = letters.Sum(Miscellaneous.ConvertLetterToNumber);
                values[i] = score * (i + 1);
            }
            
            return values.Sum();
        }
    }
}