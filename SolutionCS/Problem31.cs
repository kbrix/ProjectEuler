namespace SolutionCS
{
    public class Problem31
    {
        // Coin sums, https://projecteuler.net/problem=31
        // Use the recursive formula, https://www.algorithmist.com/index.php/Coin_Change

        private static int[] partitionOfCoins = { 1, 2, 5, 10, 20, 50, 100, 200 };

        private static int Counter(int n, int m)
        {
            if (n < 0 || m < 0)
                return 0;

            if (n == 0)
                return 1;

            return Counter(n, m - 1) + Counter(n - partitionOfCoins[m], m);
        }
        public static int Solution(int change)
        {
            return Counter(change, partitionOfCoins.Length - 1);
        }
    }
}
