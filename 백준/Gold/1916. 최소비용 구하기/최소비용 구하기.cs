using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public struct Pair
    {
        public int destination;
        public int cost;

        public Pair(int destination, int cost)
        {
            this.destination = destination;
            this.cost = cost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            int[] input;

            List<Pair>[] graph = new List<Pair>[N];

            for(int i = 0; i < N; i++)
            {
                graph[i] = new List<Pair>();
            }

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                graph[input[0] - 1].Add(new Pair(input[1] - 1, input[2]));
            }

            int s, e;

            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            s = input[0] - 1;
            e = input[1] - 1;

            int[] distance = new int[N];
            Array.Fill(distance, int.MaxValue);
            bool[] visited = new bool[N];

            distance[s] = 0;

            while (true)
            {
                int now = -1;
                int min = int.MaxValue;

                for(int i = 0; i < N; i++)
                {
                    if (visited[i])
                        continue;

                    if (distance[i] < min)
                    {
                        now = i;
                        min = distance[i];
                    }
                }

                if (now == -1)
                    break;

                visited[now] = true;

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int destination = graph[now][i].destination;
                    int cost = graph[now][i].cost;

                    if (visited[destination])
                        continue;

                    if (distance[destination] > cost + distance[now])
                    {
                        distance[destination] = cost + distance[now];
                    }
                }
            }

            Console.WriteLine(distance[e]);
        }
    }
}


