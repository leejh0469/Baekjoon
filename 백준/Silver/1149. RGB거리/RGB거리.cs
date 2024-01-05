internal class Program
{
    

    static void Main(string[] args)
    {   
        int n;
        int[,] rgb = new int[1001, 3];
        int[,] dp = new int[1001, 3];
        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            rgb[i, 0] = input[0];
            rgb[i, 1] = input[1];
            rgb[i, 2] = input[2];
        }

        dp[0,0] = rgb[0,0];
        dp[0,1] = rgb[0,1];
        dp[0,2] = rgb[0,2];

        for (int i = 1; i < n; i++)
        {
            dp[i,0] = Math.Min(dp[i-1, 1], dp[i-1, 2]) + rgb[i, 0];
            dp[i, 1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + rgb[i, 1];
            dp[i, 2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + rgb[i, 2];
        }

        Console.WriteLine(Math.Min(dp[n - 1, 0], Math.Min(dp[n - 1, 1], dp[n - 1, 2])));
    }
}