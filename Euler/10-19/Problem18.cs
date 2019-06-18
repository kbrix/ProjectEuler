using System;

namespace euler
{
    // Maximum path sum I
    // https://projecteuler.net/problem=18
    public class Problem18
    {
        public static int GeneralizedSolution(int[,] data)
        {
            for (int i = data.GetLength(0) - 2; i >= 0 ; i--)
            { 
                for (int j = 0; j <= i; j++)
                {
                    data[i, j] += Math.Max(data[i + 1, j], data[i + 1, j + 1]);
                }
            }
            return data[0, 0];
        }
    }
}