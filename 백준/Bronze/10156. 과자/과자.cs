internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = input[0] * input[1] - input[2];
        if(n <= 0)
            n = 0;
        Console.WriteLine(n);
    }
}