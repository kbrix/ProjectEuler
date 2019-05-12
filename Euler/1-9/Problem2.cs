using System.Collections.Generic;
using System.Linq;

namespace euler
{
    public class Problem2
    {
        public static int Solution()
        {
            var values = new List<int> { 1, 2 };
            var check = true;
            var i = 2;
            
            while (check)
            {
                values.Add(values[i - 2] + values[i - 1]);
                check = values[i] < 4000000;
                i++;
            }
            
            return values.Where(x => x % 2 == 0).Sum();
        }
    }
}