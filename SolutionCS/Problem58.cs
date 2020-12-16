using SolutionCS.Utility;

namespace SolutionCS
{
    public static class Problem58
    {
        public static int Solution()
        {
            var n = 1;
            var counter = 0;
            do
            {
                var a = 4 * n * n + 4 * n + 1;
                var b = 4 * n * n + 1;
                var c = 4 * n * n - 2 * n + 1;
                var d = 4 * n * n + 2 * n + 1;

                if (a.IsPrime())
                    counter++;

                if (b.IsPrime())
                    counter++;

                if (c.IsPrime())
                    counter++;

                if (d.IsPrime())
                    counter++;

                n++;
            } while (10 * counter >= 4 * n + 1);

            return 2 * n + 1;
        }
    }
}
