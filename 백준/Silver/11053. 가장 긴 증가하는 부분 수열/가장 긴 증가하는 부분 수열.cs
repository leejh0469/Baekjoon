internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] ary = new int[n+1];
        ary[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            ary[i] = input[i-1];
        }
        int[] dp = new int[n+1];

        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            int max = dp[0];
            for (int j = 0; j < i; j++)
            {
                if (ary[i] > ary[j])
                    max = Math.Max(max, dp[j]);
            }
            dp[i] = max + 1;
        }

        Console.WriteLine(dp.Max());
    }
}