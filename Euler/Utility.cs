using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    public static class Utility
    {
        public static int Mobius(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return -1;
            
            int p = 0;

            if (n % 2 == 0) // handle n=2 case separately
            {
                n = n / 2;
                p++;

                if (n % 2 == 0) return 0; // check if square-free integer
            }

            for (int i = 3; i <= Math.Sqrt(n); i = i+2)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    p++;

                    if (n % i == 0) return 0;
                }
            }

            return p % 2 == 0 ? -1 : 1; // check if number of distinct primes in the prime factorization is odd or even (function is multiplicative)
        }
        
        public static IEnumerable<int> CumulativeSum(this IEnumerable<int> sequence)
        {
            int sum = 0;
            
            foreach(var item in sequence)
            {
                sum += item;
                yield return sum;
            }        
        }


        /*public static int[] Mplus(int n)
        {
            var positiveMobiusValues = new List<int>();
            
            for (int i = 1; i <= n; i++)
            {
                var value = Mobius(i);
                if (value == 1)
                {
                    positiveMobiusValues.Add(value);
                }
            }

            return positiveMobiusValues.CumulativeSum().ToArray();
        }*/
        
        public static int Mplus(int n)
        {
            var positiveMobiusValues = new List<int>();
            
            for (int i = 1; i <= n; i++)
            {
                var value = Mobius(i);
                if (value == 1)
                {
                    positiveMobiusValues.Add(value);
                }
            }

            return positiveMobiusValues.Sum();
        }

        public static Int32 f(Int64 N)
        {
            var n1 = (decimal)Math.Pow(N, 1d / 6);
            var n2 = (decimal)Math.Pow(N, 1d / 4);

            var index = Enumerable.Range(1, (int)n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => Math.Round(x, 6));
            
            var summand = roundIndex.Select(x => Mplus((int)x));
            
            return summand.Sum();
        }
        
        public static Int32 fBIG()
        {
            var n1 = 1467799;
            var n2 = 1778279410;

            var index = Enumerable.Range(1, n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => Math.Round(x, 6));
            
            var summand = roundIndex.Select(x => Mplus((int)x));
            
            return summand.Sum();
        }
        
        /*public static int[] MobiusSieve(int max)
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
        }*/

        /*public static int Mp(int N)
        {
            var n1 = (decimal)Math.Pow(N, 1d / 6);
            var n2 = (decimal)Math.Pow(N, 1d / 4);
            
            //var n1 = 1467799;
            //var n2 = 1778279410;
            
            var m = MobiusSieve((int)n2);
            
            var mPlus = m.ToList().Select(x => Math.Max(0, x)).CumulativeSum();
            
            var index = Enumerable.Range(1, (int)n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => (int)Math.Round(x, 6));

            var s = 0;

            foreach (var a in roundIndex)
            {
                s = s + mPlus.ElementAt(a);
            }

            return s;
        }*/
        
        /*public static int MpBIG()
        {
            //var n1 = (decimal)Math.Pow(N, 1d / 6);
            //var n2 = (decimal)Math.Pow(N, 1d / 4);
            
            var n1 = 1467799;
            var n2 = 1778279410;
            
            var m = MobiusSieve((int)n2);
            
            var mList = m.ToList();
            var mPos = mList.Select(x => Math.Max(0, x));
            var mPosCumSum = mPos.CumulativeSum();
            
            var index = Enumerable.Range(1, (int)n1).Select(a => n2 / (decimal)Math.Pow(a, 3d / 2));
            var roundIndex = index.Select(x => (int)Math.Round(x, 6));

            var s = 0;

            foreach (var a in roundIndex)
            {
                s = s + mPosCumSum.ElementAt(a);
            }

            return s;
        }*/
    }
}