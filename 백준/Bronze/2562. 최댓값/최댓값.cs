internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[9];
        for (int i = 0; i < 9; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int max = 0;
        int maxIndex = -1;
        for (int i = 0;i < 9; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        Console.WriteLine(max);
        Console.WriteLine(maxIndex +1);
    }
}