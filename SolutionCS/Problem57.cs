using Rationals;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem57
    {
        public static Rational ContinuedFraction(int n)
        {
            Rational fraction = new Rational(1, 2);
            for (int i = 1; i < n; i++)
            {
                fraction = 1 / (2 + fraction);
            }

            return 1 + fraction;
        }

        public static int Solution()
        {
            var count = 0;
            for (int i = 1; i <= 1000; i++)
            {
                var fraction = ContinuedFraction(i);
                var numeratorDigitCount = fraction.Numerator.GetDigits().Count;
                var denominatorDigitCount = fraction.Denominator.GetDigits().Count;
                if (numeratorDigitCount > denominatorDigitCount)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
