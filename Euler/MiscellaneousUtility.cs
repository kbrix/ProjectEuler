using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    public static class MiscellaneousUtility 
    {
        public static int[] CumulativeSum(int[] values)
        {
            if (values == null || values.Length == 0) return new int[0];

            for (var i = 1; i < values.Length; i++)
            {
                values[i] = values[i - 1] + values[i];
            }

            return values;
        }
    }
}