namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            long[] dp = new long[101];

            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 2;
            dp[4] = 2;
            dp[5] = 3;
            dp[6] = 4;
            dp[7] = 5;
            dp[8] = 7;
            dp[9] = 9;

            for(int i = 10; i < 101; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 5];
            }
 
            for(int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());

                Console.WriteLine(dp[N - 1]);
            }
        }
    }
}
