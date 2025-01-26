namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int[,] dp = new int[1001, 1001];

            for(int i = 1; i <= s1.Length; i++)
            {
                for(int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i -1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = (int)MathF.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(dp[s1.Length, s2.Length]);
        }
    }
}


