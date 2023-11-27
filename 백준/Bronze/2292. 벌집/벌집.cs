using System;

namespace Hive
{
    class Hive
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int x = 1;

            for (int i = 0; ; i++)
            {
                x += 6 * i;
                if (x >= n)
                {
                    Console.WriteLine(i+1);
                    break;
                }
            }
        }
    }
}
