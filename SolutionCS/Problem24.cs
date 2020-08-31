using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem24
    {
        public static string Solution()
        {
            var set = new List<string>() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            var x = LinqExtensions.GetPermutations(set, set.Count);
            return String.Join("", x.ElementAt(999999).ToArray());
        }
    }
}