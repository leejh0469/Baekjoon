using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] ladder = new int[N, 3];
            int[,] dp = new int[N, 3];

            for(int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < 3; j++)
                {
                    ladder[i, j] = input[j];
                }
            }

            StringBuilder sb = new StringBuilder();

            dp[0, 0] = ladder[0, 0];
            dp[0, 1] = ladder[0, 1];
            dp[0, 2] = ladder[0, 2];

            for(int i = 1; i < N; i++)
            {
                dp[i, 0] = ladder[i, 0] + (int)MathF.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = ladder[i, 1] + (int)(MathF.Max(dp[i - 1, 0], MathF.Max(dp[i - 1, 1], dp[i - 1, 2])));
                dp[i, 2] = ladder[i, 2] + (int)Math.Max(dp[i - 1, 1], dp[i - 1, 2]);
            }

            sb.Append(MathF.Max(dp[N - 1, 0], MathF.Max(dp[N - 1, 1], dp[N - 1, 2])));
            sb.Append(" ");

            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = ladder[i, 0] + (int)MathF.Min(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = ladder[i, 1] + (int)(MathF.Min(dp[i - 1, 0], MathF.Min(dp[i - 1, 1], dp[i - 1, 2])));
                dp[i, 2] = ladder[i, 2] + (int)Math.Min(dp[i - 1, 1], dp[i - 1, 2]);
            }

            sb.Append(MathF.Min(dp[N - 1, 0], MathF.Min(dp[N - 1, 1], dp[N - 1, 2])));

            Console.WriteLine(sb.ToString());
        }
    }
}


