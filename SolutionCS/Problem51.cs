using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem51
    {
        private static IEnumerable<IEnumerable<bool>> DigitReplacementCombinations(int n)
        {
            var boolList = new List<List<bool>>();
            for (int i = 0; i < n.DigitLength(); i++)
            {
                boolList.Add(new List<bool> {false, true});
            }

            var digitReplacementCombinations = boolList.CartesianProduct().ToList();

            digitReplacementCombinations.RemoveAt(0);
            digitReplacementCombinations.RemoveAt(digitReplacementCombinations.Count - 1);

            return digitReplacementCombinations;
        }

        public static IEnumerable<int> DigitReplacementFamily(int number, bool[] combination)
        {
            if (number.DigitLength() != combination.Length)
            {
                throw new ArgumentException();
            }

            var replacementIndices = combination.FindAllIndexOf(c => c);
            var digits = number.GetDigits().ToArray();

            var numberFamily = new List<int>();

            for (int i = 0; i <= 9; i++)
            {
                foreach (var index in replacementIndices)
                {
                    digits[index] = i;
                }

                var member = digits.ConcatenateDigits();
                if (member.DigitLength() == number.DigitLength())
                {
                    numberFamily.Add(member);
                }
            }

            return numberFamily;
        }

        public static int GeneralizedSolution(int size, int max)
        {
            var primes = PrimeUtility.PrimeSieveOfEratosthenes(max);

            foreach (var p in primes)
            {
                var digitReplacementCombinations = DigitReplacementCombinations(p);
                foreach (var combination in digitReplacementCombinations)
                {
                    var numberFamily = DigitReplacementFamily(p, combination.ToArray());
                    var primeFamily = numberFamily.Where(x => x.IsPrime());

                    if (primeFamily.Count() == size)
                    {
                        return primeFamily.First();
                    }
                }
            }

            return 0;
        }

        public static int Solution()
        {
            return GeneralizedSolution(8, 200_000);
        }
    }
}
