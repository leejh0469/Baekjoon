internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] ary = new int[501, 501];
        int[,] dp = new int[501, 501];

        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < input.Length; j++)
            {
                ary[i, j] = input[j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            dp[n-1, i] = ary[n-1, i];
        }

        for(int i = n-2; i >= 0; i--)
        {
            for(int j = 0;j <= i; j++)
            {
                dp[i, j] = Math.Max(dp[i + 1, j] , dp[i+1, j+1]) + ary[i,j];
            }
        }


        Console.WriteLine(dp[0, 0]);
    }
}