using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem69
    {
        public static int Solution(int max)
        {
            var ratios = new List<double>();
            for (int i = 2; i <= max; i++)
            {
                double n = i;
                double phi = i.EulerTotientFunction();
                double ratio = n / phi;

                ratios.Add(ratio);
            }

            var maxRatio = ratios.Max();
            var maxRatioIndex = ratios.IndexOf(maxRatio);
            return maxRatioIndex + 2;
        }
    }
}
