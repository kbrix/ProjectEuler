using System;
using System.Collections.Generic;
using System.Linq;
using SolutionCS.Utility;

namespace SolutionCS
{
    public class Problem61
    {
        private static Func<int, int> TriangleNumberFunc = n => n * (n + 1) / 2;
        private static Func<int, int> SquareNumberFunc = n => n * n;
        private static Func<int, int> PentagonNumberFunc = n => n * (3 * n - 1) / 2;
        private static Func<int, int> HexagonNumberFunc = n => n * (2 * n - 1);
        private static Func<int, int> HeptagonNumberFunc = n => n * (5 * n - 3) / 2;
        private static Func<int, int> OctagonNumberFunc = n => n * (3 * n - 2);

        private static HashSet<int> TriangleNumbers = GetNumbers(TriangleNumberFunc).ToHashSet();
        private static HashSet<int> SquareNumbers = GetNumbers(SquareNumberFunc).ToHashSet();
        private static HashSet<int> PentagonNumbers = GetNumbers(PentagonNumberFunc).ToHashSet();
        private static HashSet<int> HexagonNumbers = GetNumbers(HexagonNumberFunc).ToHashSet();
        private static HashSet<int> HeptagonNumbers = GetNumbers(HeptagonNumberFunc).ToHashSet();
        private static HashSet<int> OctagonNumbers = GetNumbers(OctagonNumberFunc).ToHashSet();

        private static Func<int, bool> IsTriangle = n => TriangleNumbers.Contains(n);
        private static Func<int, bool> IsSquare = n => SquareNumbers.Contains(n);
        private static Func<int, bool> IsPentagon = n => PentagonNumbers.Contains(n);
        private static Func<int, bool> IsHexagon = n => HexagonNumbers.Contains(n);
        private static Func<int, bool> IsHeptagon = n => HeptagonNumbers.Contains(n);
        private static Func<int, bool> IsOctagon = n => OctagonNumbers.Contains(n);

        private static ISet<int> GetNumbers(Func<int, int> f)
        {
            var n = 1;
            var triangleNumbers = new HashSet<int>();

            while (true)
            {
                var number = f.Invoke(n);
                var digitLength = number.DigitLength();

                if (digitLength <= 4)
                    n++;

                if (digitLength == 4)
                    triangleNumbers.Add(number);

                if (digitLength > 4)
                    break;
            }

            return triangleNumbers;
        }

        public static ISet<(int x0, int x1, int x2)> Example()
        {

            var cyclicalNumbers = new List<(int x0, int x1, int x2)>();
            for (var i = 0; i < TriangleNumbers.Count; i++)
            {
                for (var c = 10; c <= 99; c++)
                {
                    var ab = TriangleNumbers.ElementAt(i);
                    var a = int.Parse(ab.ToString()[0 .. (1+1)]);
                    var b = int.Parse(ab.ToString()[2 .. (3+1)]);
                    cyclicalNumbers.Add((a.Concatenate(b), b.Concatenate(c), c.Concatenate(a)));
                }
            }

            return cyclicalNumbers.Where(Condition3).ToHashSet();
        }

		public static int Solution()
        {
			var cyclicalNumbers = new List<(int x0, int x1, int x2, int x3, int x4, int x5)>();
			for (var i = 0; i < TriangleNumbers.Count; i++)
			{
				for (var c = 10; c <= 99; c++)
				{
					for (var d = 10; d <= 99; d++)
					{
						var cd = c.Concatenate(d);
						if (!IsSpecialNumber(cd))
							continue;

						for (var e = 10; e <= 99; e++)
						{
							var de = d.Concatenate(e);
							if (!IsSpecialNumber(de))
								continue;

							for (var f = 10; f <= 99; f++)
							{
								var ef = e.Concatenate(f);
								if (!IsSpecialNumber(ef))
									continue;

								var ab = TriangleNumbers.ElementAt(i);
								var a = int.Parse(ab.ToString()[0..(1 + 1)]);
								var b = int.Parse(ab.ToString()[2..(3 + 1)]);

								var cyclicalNumber = (
									a.Concatenate(b),
									b.Concatenate(c),
									c.Concatenate(d),
									d.Concatenate(e),
									e.Concatenate(f),
									f.Concatenate(a));
								
								if (Condition6(cyclicalNumber))
									cyclicalNumbers.Add(cyclicalNumber);
							}
						}
					}
				}
			}

			var (x0, x1, x2, x3, x4, x5) = cyclicalNumbers.First();
			Console.WriteLine($"{x0} + {x1} + {x2} + {x3} + {x4} + {x5}");
			return x0 + x1 + x2 + x3 + x4 + x5;
        }

		private static bool IsSpecialNumber (int n)
        {
			return IsOctagon(n) || IsHeptagon(n) || IsHexagon(n) || IsPentagon(n) || IsSquare(n) || IsTriangle(n);

		} 

        private static Func<(int x0, int x1, int x2), bool> Condition3 = x =>
            (IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2)) ||
            (IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2)) ||
            (IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2)) ||
            (IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2)) ||
            (IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2)) ||
            (IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2));

		private static Func<(int x0, int x1, int x2, int x3, int x4, int x5), bool> Condition6 = x =>
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsTriangle(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsSquare(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsPentagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHeptagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsOctagon(x.x4) && IsHexagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsTriangle(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsSquare(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsOctagon(x.x3) && IsPentagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsOctagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsOctagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsOctagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsOctagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsOctagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsOctagon(x.x3) && IsHexagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsOctagon(x.x4) && IsHeptagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsTriangle(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsSquare(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsHexagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsHeptagon(x.x3) && IsPentagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsTriangle(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHeptagon(x.x2) && IsSquare(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHeptagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHeptagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHeptagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHeptagon(x.x2) && IsPentagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHeptagon(x.x3) && IsHexagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsTriangle(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsPentagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsHexagon(x.x2) && IsSquare(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsHexagon(x.x1) && IsTriangle(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsHexagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsHexagon(x.x1) && IsSquare(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsHexagon(x.x2) && IsPentagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsSquare(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsPentagon(x.x1) && IsTriangle(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsPentagon(x.x0) && IsTriangle(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsPentagon(x.x1) && IsSquare(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsSquare(x.x0) && IsTriangle(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5)) ||
			(IsTriangle(x.x0) && IsSquare(x.x1) && IsPentagon(x.x2) && IsHexagon(x.x3) && IsHeptagon(x.x4) && IsOctagon(x.x5));
	}
}
