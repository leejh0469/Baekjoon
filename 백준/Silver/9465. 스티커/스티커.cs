using System.Buffers;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for(int i = 0; i < T; i++)
            {
                int n  = int.Parse(Console.ReadLine());

                int[,] stickers = new int[2, n];
                int[,] dp = new int[2, n];

                int[] input;
                
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < n; j++)
                {
                    stickers[0, j] = input[j];
                }

                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < n; j++)
                {
                    stickers[1, j] = input[j];
                }

                dp[0, 0] = stickers[0, 0];
                dp[1, 0] = stickers[1, 0];

                for(int j = 1; j < n; j++)
                {
                    if(j == 1)
                    {
                        dp[0, j] = dp[1, 0] + stickers[0, j];
                        dp[1, j] = dp[0, 0] + stickers[1, j];
                    }
                    else
                    {
                        dp[0, j] = (int)MathF.Max(MathF.Max(dp[0, j - 2], dp[1, j - 2]), dp[1, j - 1]) + stickers[0, j];
                        dp[1, j] = (int)MathF.Max(MathF.Max(dp[0, j - 2], dp[1, j - 2]), dp[0, j - 1]) + stickers[1, j];
                    }
                }

                Console.WriteLine(MathF.Max(dp[0, n - 1], dp[1, n - 1]));
            }
        }
    }
}


