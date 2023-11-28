using System;
using System.Linq;

namespace TaleList
{
    class TaleList
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] number = input.Split(' ').Select(n => Convert.ToInt32(n) -1).ToArray();

            int width = 0;
            int height = 0;

            width = Math.Abs(number[0]/4 - number[1]/4);

            int a = number[0] % 4;
            int b = number[1] % 4;

            height = Math.Abs(a - b);

            Console.WriteLine(width + height);
        }
    }
}
