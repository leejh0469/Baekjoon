using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public struct Path
    {
        public int next;
        public int cost;

        public Path(int next, int cost)
        {
            this.next = next;
            this.cost = cost;
        }
    }

    internal class Program
    {
        static readonly int INF = 10000000;

        static void Main(string[] args)
        {
            int N, E;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            E = input[1];

            List<Path>[] graph = new List<Path>[N + 1];

            for(int i = 1; i <= N; i++)
            {
                graph[i] = new List<Path>();
            }

            for(int i = 0; i < E; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                graph[input[0]].Add(new Path(input[1], input[2]));
                graph[input[1]].Add(new Path(input[0], input[2]));
            }

            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int v1 = input[0];
            int v2 = input[1];

            int sToV1 = Dijkstra(N, 1, v1, graph);
            int sToV2 = Dijkstra(N, 1, v2, graph);

            int v1ToV2 = Dijkstra(N, v1, v2, graph);

            int v1ToE = Dijkstra(N, v1, N, graph);
            int v2ToE = Dijkstra(N, v2, N, graph);

            int path = sToV1 + v1ToV2 + v2ToE;

            path = path < (sToV2 + v1ToV2 + v1ToE) ? path : (sToV2 + v1ToV2 + v1ToE);

            if (path >= INF)
                Console.WriteLine(-1);
            else
                Console.WriteLine(path);
        }

        static int Dijkstra(int N, int s, int e, List<Path>[] graph)
        {
            int[] distance = new int[N + 1];
            bool[] visited = new bool[N + 1];

            for(int i = 1; i <= N; i++)
            {
                distance[i] = INF;
            }

            distance[s] = 0;

            while (true)
            {
                int now = -1;
                int min = INF;

                for(int i = 1; i <= N; i++)
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
                    int next = graph[now][i].next;
                    int cost = graph[now][i].cost;

                    if (visited[next])
                        continue;

                    if (distance[next] > cost + distance[now])
                        distance[next] = cost + distance[now];
                }
            }

            return distance[e];
        }
    }
}


