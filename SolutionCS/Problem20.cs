﻿using System.Linq;
using System.Numerics;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem20
    {
        public static int GeneralizedSolution(BigInteger n)
        {
            return n.Factorial().ToString().ToCharArray().Select(v => int.Parse(v.ToString())).Sum();
        }

        public static int Solution()
        {
            return GeneralizedSolution(100);
        }
    }
}
