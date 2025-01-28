using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static long A, B, C;

        static void Main(string[] args)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            A = input[0];
            B = input[1];
            C = input[2];

            Console.WriteLine(DaC(A, B));

            long DaC(long a, long b)
            {
                if (b == 1)
                    return a % C;

                long value = DaC(a, b / 2);

                if(b % 2 == 0)
                {
                    return value * value % C;
                }
                else
                {
                    return (value * value % C) * a % C;
                }
            }
        }
    }
}


