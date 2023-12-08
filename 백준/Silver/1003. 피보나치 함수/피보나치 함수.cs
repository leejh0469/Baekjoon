using System;

namespace Fibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = int.Parse(Console.ReadLine());
            }

            int[,] dp = new int[41, 2];
            dp[0, 0] = dp[1, 1] = 1;


            for (int i = 0; i < n; i++)
            {
                for (int j = 2; j <= x[i]; j++)
                {
                    dp[j, 0] = dp[j - 1, 0] + dp[j - 2, 0];
                    dp[j, 1] = dp[j - 1, 1] + dp[j - 2, 1];
                }

                Console.WriteLine(dp[x[i],0] + " " + dp[x[i],1]);
            }
        }
    }
}
