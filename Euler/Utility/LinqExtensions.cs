using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public static IEnumerable<IEnumerable<T>> GetPermutationsWithRepetition<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(x => new T[] { x });
            }

            return
                GetPermutationsWithRepetition(list, length - 1)
                    .SelectMany(
                        x => list,
                        (x1, x2) => x1.Concat(new T[] {x2})
                    );
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(x => new T[] { x });
            }

            return
                GetPermutations(list, length - 1)
                    .SelectMany(
                        x => list.Where(y => !x.Contains(y)), 
                        (x1, x2) => x1.Concat(new T[] {x2})
                    );
        }

        public static List<int> GetDigits(this int number)
        {
            var n = Math.Floor( Math.Log10( Math.Abs(number) ) ) + 1;
            var list = new List<int>();
            
            for (int i = 0; i < n; i++)
            {
                var x = (number / Math.Pow(10, i)) % 10;
                list.Add((int)Math.Floor(x));
            }
            
            list.Reverse();
            return list;
        }

        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> elements, int number = 1)
        {
            var elementsList = elements as IList<T> ?? elements.ToList();
            var list = new List<T>(elementsList.Count);

            if (number > elementsList.Count - 1)
            {
                throw new ArgumentException(nameof(number));
            }

            for (int i = number; i < elementsList.Count; i++)
            {
                list.Add(elementsList[i]);
            }

            for (int i = 0; i < number; i++)
            {
                list.Add(elementsList[i]);
            }

            return list;
        }

        public static int ConcatenateDigits(this IEnumerable<int> elements)
        {
            var digits = elements.ToArray();
            var powers = Enumerable.Range(0, digits.Length).Reverse().ToArray();
            var result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                result += (int) Math.Pow(10, powers[i]) * digits[i];
            }

            return result;
        }
    }
}