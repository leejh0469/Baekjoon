namespace Backjoon15963
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            if (input[0] == input[1])
                Console.WriteLine("1");
            else
                Console.WriteLine("0");
        }
    }
}