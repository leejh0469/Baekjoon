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
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for(int i = 1; i <= s1.Length; i++)
            {
                for(int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            List<char> list = new List<char>();

            int x = s1.Length;
            int y = s2.Length;

            while(x > 0 && y > 0)
            {
                if (s1[x - 1] == s2[y - 1])
                {
                    list.Add(s1[x - 1]);
                    x--;
                    y--;
                }
                else
                {
                    if (dp[x - 1, y] >= dp[x, y - 1])
                    {
                        x--;
                    }
                    else
                        y--;
                }
            }

            list.Reverse();

            Console.WriteLine(dp[s1.Length, s2.Length]);
            foreach(char c in list)
            {
                Console.Write(c);
            }
        }
    }
}