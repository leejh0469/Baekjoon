using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    public struct Node
    {
        public int node;
        public int cost;

        public Node(int node, int cost)
        {
            this.node = node;
            this.cost = cost;
        }
    }


    internal class Program
    {
        public static readonly int INF = 3000;

        static void Main(string[] args)
        {
            int n, m, r;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            n = input[0];
            m = input[1];
            r = input[2];

            int[] t = new int[n + 1];


            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            for (int i = 1; i <= n; i++)
            {
                t[i] = input[i - 1];
            }

            List<Node>[] graph = new List<Node>[n + 1];

            int[,] distance = new int[n + 1, n + 1];

            for(int i = 0; i <= n; i++)
            {
                graph[i] = new List<Node>();
            }

            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if(i == j)
                        continue;

                    distance[i, j] = INF;
                }
            }

            for(int i = 0; i < r; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int a = input[0];
                int b = input[1];
                int cost = input[2];

                graph[a].Add(new Node(b, cost));
                graph[b].Add(new Node(a, cost));

                distance[a, b] = cost;
                distance[b, a] = cost;
            }

            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    for(int k = 1;  k <= n; k++)
                    {
                        distance[j, k] = Math.Min(distance[j, k], distance[j, i] + distance[i, k]);
                    }
                }
            }

            int max = 0;

            for(int i = 1; i <= n; i++)
            {
                int total = 0;

                for(int j = 1; j <= n; j++)
                {
                    if (distance[i, j] <= m)
                        total += t[j];
                }

                if( total > max ) max = total;
            }

            Console.WriteLine(max);
        }
    }
}
