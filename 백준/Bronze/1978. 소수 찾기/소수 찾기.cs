using System;
using System.Linq;

namespace FindDecimal
{
    class FindDecimal
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] number = new int[n];

            string input = Console.ReadLine();
            number = input.Split(' ').Select(n=> Convert.ToInt32(n)).ToArray();

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                bool check = true;

                if (number[i] >= 2)
                {
                    for (int j = 2; j <= number[i] / 2; j++)
                    {
                        if (number[i] % j == 0)
                        {
                            check = false;
                            break;
                        }
                    }
                }
                else
                    check = false;

                if (check)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
