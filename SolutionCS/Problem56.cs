using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem56
    {
        public static int Solution()
        {
            var maximumDigitSum = 0;

            for (int i = 1; i <= 99; i++)
            {
                for (int j = 1; j <= 99; j++)
                {
                    var digitSum = BigInteger.Pow(i, j).DigitSum();
                    maximumDigitSum = digitSum > maximumDigitSum ? digitSum : maximumDigitSum;
                }
            }

            return maximumDigitSum; // 99^95, 972
        }
    }
}
