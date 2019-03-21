using System;
using System.Linq;

namespace euler
{
    public class MoreUtility
    {
        public static int[] MobiusSieve(int max)
        {
            var sqrt = (int)Math.Floor(Math.Sqrt(max));
            
            var mu = new int[max + 1];

            for (int i = 1; i <= max; i++)
            {
                mu[i] = 1;
            }
            
            for (int i = 2; i <= sqrt; i++)
            {
                if (mu[i] == 1)
                {
                    for (int j = i; j <= max; j += i)
                    {
                        mu[j] *= -i;
                    }

                    for (int j = i * i; j <= max && j > 1; j += i * i)
                    {
                        mu[j] = 0;
                    }
                }
            }
            
            for (int i = 2; i <= max; i++)
            {
                if (mu[i] == i)
                {
                    mu[i] = 1;
                }
                else if (mu[i] == -i)
                {
                    mu[i] = -1;
                }
                else if (mu[i] < 0)
                {
                    mu[i] = 1;
                }
                else if (mu[i] > 0)
                {
                    mu[i] = -1;
                }
            }
            
            return mu;
        }
        
        /*public static int[] CumulativeSum(int[] values)
        {
            if (values == null || values.Length == 0) return new int[0];

            var result = new int[values.Length];
            
            result[0] = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                result[i] = result[i - 1] + values[i];
            }

            return result;
        }*/
        
        public static int[] CumulativeSum(int[] values)
        {
            if (values == null || values.Length == 0) return new int[0];

            //var result = new int[values.Length];
            
            //result[0] = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                values[i] = values[i - 1] + values[i];
            }

            return values;
        }
        
        public static int Mp(int N)
        {
            var n1 = (decimal)Math.Pow(N, 1d / 6);
            var n2 = (decimal)Math.Pow(N, 1d / 4);
            
            //var n1 = 1467799;
            //var n2 = 1778279410;
            
            var m = MobiusSieve((int)n2);

            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != 1)
                {
                    m[i] = 0;
                }
            }

            var mCumulativeSum = CumulativeSum(m);
                        
            var index = Enumerable.Range(1, (int)n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => (int)Math.Round(x, 6));

            var s = 0;

            foreach (var a in roundIndex)
            {
                s = s + mCumulativeSum.ElementAt(a);
            }

            return s;
        }
        
        
        public static int MpBIG()
        {
            //var n1 = (decimal)Math.Pow(N, 1d / 6);
            //var n2 = (decimal)Math.Pow(N, 1d / 4);
            
            var n1 = 1000000; // 10^6
            var n2 = 1000000000; // 10^9
            
            var m = MobiusSieve((int)n2);
            
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != 1)
                {
                    m[i] = 0;
                }
            }

            var mCumulativeSum = CumulativeSum(m);
                        
            var index = Enumerable.Range(1, (int)n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => (int)Math.Round(x, 6));

            var s = 0;

            foreach (var a in roundIndex)
            {
                s = s + mCumulativeSum.ElementAt(a);
            }

            return s;
        }
    }
}