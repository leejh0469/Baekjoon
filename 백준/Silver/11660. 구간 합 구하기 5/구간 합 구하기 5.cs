using System.Buffers;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N, M;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];

            int[,] matrix = new int[N, N];
            int[,] dp = new int[N + 1, N + 1];

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < N; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 1; i <= N; i++)
            {
                for(int j = 1; j <= N; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1] - dp[i - 1, j - 1] + matrix[i - 1, j - 1];
                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int x1, y1, x2, y2;

                x1 = input[0];
                y1 = input[1];
                x2 = input[2];
                y2 = input[3];

                sb.Append(dp[x2, y2] - dp[x2, y1 - 1] - dp[x1 - 1, y2] + dp[x1 - 1, y1 - 1]);
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}


