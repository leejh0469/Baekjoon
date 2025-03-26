using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int[] increase = new int[N];
            int[] decrease = new int[N];

            increase[0] = 1;

            for(int i = 1; i < N; i++)
            {
                int max = 0;

                for(int j = 0; j < i; j++)
                {
                    if (array[i] > array[j])
                        max = Math.Max(max, increase[j]);
                }

                increase[i] = max + 1;
            }

            decrease[N - 1] = 1;

            for (int i = N - 2; i >= 0; i--)
            {
                int max = 0;

                for (int j = N - 1; j > i; j--)
                {
                    if (array[i] > array[j])
                        max = Math.Max(max, decrease[j]);
                }

                decrease[i] = max + 1;
            }

            int sum = 1;

            for (int i = 0; i < N; i++)
            {
                if (increase[i] + decrease[i] > sum)
                {
                    sum = increase[i] + decrease[i];
                }
            }

            Console.WriteLine(sum - 1);
        }
    }
}
