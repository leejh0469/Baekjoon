using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int a, b, c;
            a = input[0];
            b = input[1];
            c = input[2];

            int price = 0;

            if (a == b && b == c)
            {
                price = 10000 + a * 1000;
            }
            else if (a == b || a == c)
            {
                price = 1000 + a * 100;
            }
            else if(b == c)
            {
                price = 1000 + b * 100;
            }
            else
            {
                int max = Math.Max(a, Math.Max(b, c));

                price = max * 100;
            }

            Console.WriteLine(price);
        }
    }
}
