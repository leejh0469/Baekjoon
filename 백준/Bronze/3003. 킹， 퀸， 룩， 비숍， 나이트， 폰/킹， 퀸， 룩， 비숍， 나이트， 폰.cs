using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int[] piece = { 1, 1, 2, 2, 2, 8 };
            for(int i = 0; i < input.Length; i++)
            {
                Console.Write(piece[i] - input[i] + " ");
            }
        }
    }
}
