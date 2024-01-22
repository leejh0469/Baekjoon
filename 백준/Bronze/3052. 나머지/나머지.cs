internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i< 10; i++)
        {
            int remain = arr[i] % 42;
            if (dict.ContainsKey(remain))
            {
                dict[remain]++;
            }
            else
            {
                dict[remain] = 1;
            }
        }

        Console.WriteLine(dict.Count);
    }
}