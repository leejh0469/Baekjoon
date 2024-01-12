internal class Program
{

    static int n;
    static int k;
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        n = input[0];
        k = input[1];

        int[] arr = new int[n];

        for (int i = 0;  i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int count = 0;

        for (int i = n -1; i >= 0; i--)
        {
            if (arr[i] <= k)
            {
                count += k / arr[i];
                k %= arr[i];
            }
        }
        Console.WriteLine(count);
    }
}