using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace euler.Utility
{
    public static class LinqExtensions
    {
        public static double Median<TCollection, TValue>(this IEnumerable<TCollection> source, Func<TCollection, TValue> selector)
        {
            return source.Select(selector).Median();
        }

        public static double Median<T>(this IEnumerable<T> source)
        {
            var count = source.Count();
            
            if (count == 0)
            {
                throw new ArgumentException($"The collection '{source}' may not be empty");
            }

            source = source.OrderBy(n => n);

            var midPoint = count / 2;
            
            if (count % 2 == 0)
            {
                return (Convert.ToDouble(source.ElementAt(midPoint - 1)) + Convert.ToDouble(source.ElementAt(midPoint))) / 2.0;
            }
            else
            {
                return Convert.ToDouble(source.ElementAt(midPoint));
            }
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(x => new T[] {x});
            }

            return
                GetPermutations(list, length - 1)
                    .SelectMany(x => list
                        .Where(y => !x.Contains(y)), 
                        (x1, x2) => x1.Concat(new T[] {x2})
                        );
        }

    }
}