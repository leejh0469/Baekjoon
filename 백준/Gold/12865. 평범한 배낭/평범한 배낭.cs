using System.Runtime.Intrinsics.Arm;

namespace Backjoon12865
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int k = input[1];

            Pair<int, int>[] p = new Pair<int, int>[n+1];
            int[,] dp = new int[n+1, k+1];
            for (int i = 1; i <= n; i++)
            {
                int[] input2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                p[i] = new Pair<int, int>(input2[0], input2[1]);
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    if(j >= p[i].First)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], p[i].Second + dp[i - 1, j - p[i].First]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine(dp[n, k]);
        }
    }
}
