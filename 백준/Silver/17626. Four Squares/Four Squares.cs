using System.Runtime.Intrinsics.Arm;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dp = new int[50001];

            dp[1] = 1;

            for(int i = 2; i <=  n; i++)
            {
                int min = 50000;

                for(int j = 1; j * j <= i; j++)
                {
                    int temp = i - j * j;

                    min = (int)Math.Min(min, dp[temp]);
                }

                dp[i] = dp[min] + 1;
            }

            Console.WriteLine(dp[n]);
        }
    }
}


