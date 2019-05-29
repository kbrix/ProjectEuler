using System.Linq;

namespace euler
{
    public static class Problem12
    {
        public static int GeneralizedSolution(int d)
        {
            var n = 1;
            var numberOfDivisors = n.Factorize().Count();

            var triangleNumber = new int();
            
            while (numberOfDivisors <= d)
            {
                n++;
                triangleNumber = n * (n + 1) / 2;
                numberOfDivisors = triangleNumber.DivisorFunction();
            }

            return triangleNumber;
        }

        public static int Solution()
        {
            return GeneralizedSolution(500);
        }
    }
}