using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    public class Pair
    {
        public int first;
        public int second;

        public Pair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int N, K;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            N = input[0];
            K = input[1];

            int[] distance = new int[100001];
            bool[] visited = new bool[100001];

            Queue<Pair> q = new Queue<Pair>();

            q.Enqueue(new Pair(N, 0));
            visited[N] = true;

            bool firstVisit = true;
            int result = 0;
            int count = 0;

            while(q.Count > 0)
            {
                Pair p = q.Dequeue();

                int x = p.first;
                int d = p.second;

                visited[x] = true;

                if(x == K)
                {
                    if (firstVisit)
                    {
                        firstVisit = false;
                        result = d;
                        count++;
                    }
                    else
                    {
                        if (d == result)
                        {
                            count++;
                        }
                    }
                    continue;
                }

                int next = x - 1;

                if (next < 100001 && next >= 0 && !visited[next])
                {
                    q.Enqueue(new Pair(next, d + 1));
                }

                next = x + 1;

                if (next < 100001 && next >= 0 && !visited[next])
                {
                    q.Enqueue(new Pair(next, d + 1));
                }

                next = x * 2;

                if (next < 100001 && next >= 0 && !visited[next])
                {
                    q.Enqueue(new Pair(next, d + 1));
                }
            }

            Console.WriteLine(result);
            Console.WriteLine(count);
        }
    }
}
