using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SolutionCS.Utility
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

        // see Pengyang's answer: https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array
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

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(x => new T[] { x });
            }

            return
                GetPermutations(list, length - 1)
                    .SelectMany(
                        x => list.Where(y => !x.Contains(y)), 
                        (x1, x2) => x1.Concat(new T[] { x2 })
                    );
        }

        public static IEnumerable<IEnumerable<T>> GetCombinationsWithRepetition<T>(this IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return 
                GetCombinationsWithRepetition(list, length - 1)
                    .SelectMany(
                        t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                        (t1, t2) => t1.Concat(new T[] { t2 })
                    );
        }

        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return 
                GetCombinations(list, length - 1)
                    .SelectMany(
                        t => list.Where(o => o.CompareTo(t.Last()) > 0),
                        (t1, t2) => t1.Concat(new T[] { t2 })
                    );
        }

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> enumerables)
        {
            static IEnumerable<IEnumerable<T>> Seed() { yield return Enumerable.Empty<T>(); }

            return enumerables.Aggregate(Seed(), (accumulator, enumerable) =>
                accumulator.SelectMany(x => enumerable.Select(x.Append)));
        }

        public static List<int> GetDigits(this int number)
        {
            var n = Math.Floor(Math.Log10(Math.Abs(number))) + 1;
            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var x = (number / Math.Pow(10, i)) % 10;
                list.Add((int)Math.Floor(x));
            }

            list.Reverse();
            return list;
        }

        public static List<int> GetDigits(this long number)
        {
            var n = Math.Floor(Math.Log10(Math.Abs(number))) + 1;
            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var x = (number / Math.Pow(10, i)) % 10;
                list.Add((int)Math.Floor(x));
            }

            list.Reverse();
            return list;
        }

        public static Stack<int> GetDigits(this BigInteger number, int baseNumber = 10)
        {
            var digits = new Stack<int>();
            while (number > 0)
            {
                var digit = number % baseNumber;
                digits.Push((int) digit);
                number /= baseNumber;
            }
            return digits;
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
                result += (int)Math.Pow(10, powers[i]) * digits[i];
            }

            return result;
        }

        public static long ConcatenateDigits(this IEnumerable<long> elements)
        {
            var digits = elements.ToArray();
            var result = string.Empty;

            for (int i = 0; i < digits.Length; i++)
            {
                result += digits[i].ToString();
            }

            return long.Parse(result);
        }

        public static BigInteger ConcatenateDigits(this IEnumerable<BigInteger> elements)
        {
            var digits = elements.ToArray();
            var powers = Enumerable.Range(0, digits.Length).Reverse().ToArray();
            BigInteger result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                result += BigInteger.Pow(10, powers[i]) * digits[i];
            }

            return result;
        }

        public static List<T[]> Window<T>(this T[] elements, int n)
        {
            if (!(n >= 1))
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Window length must be a natural number.");
            }

            var length = elements.Length;

            if (n > length)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Window length is larger than array.");
            }

            var collection = new List<T[]>();
            for (int i = 0; i <= length - n; i++)
            {
                var subArray = elements[i .. (i + n)];
                collection.Add(subArray);
            }

            return collection;
        }

        public static int[] FindAllIndexOf<T>(this IEnumerable<T> values, Func<T, bool> predicate)
        {
            return values.Select((v, i) => predicate(v) ? i : -1).Where(i => i != -1).ToArray();
        }

        /// <summary>
        /// Repeats an enumerable after the first element a given number of times. 
        /// </summary>
        /// <param name="source">The source to repeat.</param>
        /// <typeparam name="T">The type of the elements in the source.</typeparam>
        /// <returns>The sequence of repeated values. The first value is not repeated.</returns>
        public static IEnumerable<T> AfterFirstRepeatTimes<T>(this IEnumerable<T> source, int n)
        {
            var array = source.ToArray();
            yield return array[0];

            var times = 0;
            var arrayTail = array[1 .. ];
            
            do
            {
                times++;
                
                foreach (T item in arrayTail)
                {
                    yield return item;
                }
            }
            while (times < n);
        }
    }
}