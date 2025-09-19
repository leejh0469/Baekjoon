using System.Text;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        // 모듈러 값을 상수로 정의
        static long MOD = 1000000007;

        static void Main(string[] args)
        {
            int C, N;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            C = input[0];
            N = input[1];

            List<(int, int)> list = new List<(int, int)>();

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                list.Add((input[0], input[1]));
            }

            int[] dp = new int[C + 100];

            dp[0] = 0;

            for(int i = 1; i < dp.Length; i++)
            {
                dp[i] = 10000001;
            }

            foreach((int, int) i in list)
            {
                for(int j = i.Item2; j < dp.Length; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j - i.Item2] + i.Item1);
                }
            }

            int min = int.MaxValue;

            for(int i = C; i < dp.Length; i++)
            {
                if(min > dp[i])
                    min = dp[i];
            }

            Console.WriteLine(min);
        }
    }
}