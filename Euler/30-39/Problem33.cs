using euler.Utility;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    public class Problem33
    {
        public static int Solution()
        {
            var s = 1;

            for (int i = 10; i <= 99; i++)
            {
                for (int j = 10; j <= 99; j++)
                {
                    var x = i.GetDigits();
                    var y = j.GetDigits();

                    (x.Union(y)).Intersect(x.Intersect(y));

                    var n = x.ToArray();
                    
                    if (x.Count == 2)
                    {
                        if (i/j == n[0]/n[1])
                        {
                            s *= n[1];
                        }
                    }
                    
                }
            }
            
            return s;
        }
    }
}