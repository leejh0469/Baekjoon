using System.Buffers;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int A, B;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            A = input[0];
            B = input[1];

            Dictionary<long, long> dict = new Dictionary<long, long>();

            Queue<long> q = new Queue<long>();

            q.Enqueue(A);
            dict.Add(A, 1);

            long value;
            long x;

            while (q.Count > 0)
            {
                value = q.Dequeue();

                if(value == B)
                {
                    Console.WriteLine(dict[value]);
                    return;
                }

                x = value * 2;
                if(x <= B && !dict.ContainsKey(x))
                {
                    q.Enqueue(x);
                    dict.Add(x, dict[value] + 1);
                }

                x = value * 10 + 1;
                if(x <= B && !dict.ContainsKey(x))
                {
                    q.Enqueue(x);
                    dict.Add(x, dict[value] + 1);
                }
            }

            Console.WriteLine(-1);
        }
    }
}


