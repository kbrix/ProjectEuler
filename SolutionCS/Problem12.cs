using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem12
    {
        public static int GeneralizedSolution(int d)
        {
            var n = 1;
            //var numberOfDivisors = n.Factorize().Count();
            var numberOfDivisors = n.GetNumberOfDivisors();

            var triangleNumber = new int();
            
            while (numberOfDivisors <= d)
            {
                n++;
                triangleNumber = n * (n + 1) / 2;
                numberOfDivisors = triangleNumber.GetNumberOfDivisors();
            }

            return triangleNumber;
        }

        public static int Solution()
        {
            return GeneralizedSolution(500);
        }
    }
}