internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if(n == input[i]) count++;
        }
        Console.WriteLine(count);
    }
}