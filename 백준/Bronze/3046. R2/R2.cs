internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int r1 = input[0];
        int s = input[1];

        Console.WriteLine(2*s - r1);
    }
}