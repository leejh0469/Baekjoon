using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    public struct Pair
    {
        public int x;
        public int y;

        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Pair> list = new List<Pair>();

            for (int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                list.Add(new Pair(input[0], input[1]));
            }

            list.Sort((Pair a, Pair b) =>
            {
                if (a.y == b.y)
                    return a.x.CompareTo(b.x);
                return a.y.CompareTo(b.y);
            });

            StringBuilder sb = new StringBuilder();

            foreach(Pair pair in list)
            {
                sb.AppendLine(pair.x + " " + pair.y);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}


