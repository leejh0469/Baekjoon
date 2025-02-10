using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static readonly int INF = 5000001;

        public struct Edge
        {
            public int curNode;
            public int nextNode;
            public int cost;

            public Edge(int curNode, int nextNode, int cost)
            {
                this.curNode = curNode;
                this.nextNode = nextNode;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            int TC = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < TC; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int N, M, W;
                N = input[0];
                M = input[1];
                W = input[2];

                List<Edge> edges = new List<Edge>();

                int[] distance = new int[N];
                Array.Fill(distance, INF);

                for(int j = 0; j < M; j++)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                    edges.Add(new Edge(input[0] - 1, input[1] - 1, input[2]));
                    edges.Add(new Edge(input[1] - 1, input[0] - 1, input[2]));
                }

                for (int j = 0; j < W; j++)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                    edges.Add(new Edge(input[0] - 1, input[1] - 1, input[2] * -1));
                }

                bool hasNegativeCost = BellmanFord(N, M, W, distance, edges);

                if(hasNegativeCost)
                {
                    sb.AppendLine("YES");
                }
                else
                {
                    sb.AppendLine("NO");
                }
            }

            Console.WriteLine(sb.ToString());

            bool BellmanFord(int N, int M, int W, int[] distance, List<Edge> edges)
            {
                distance[0] = 0;

                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < edges.Count; k++)
                    {
                        Edge edge = edges[k];

                        int curNode = edge.curNode;
                        int nextNode = edge.nextNode;
                        int cost = edge.cost;

                        if (distance[curNode] + cost < distance[nextNode])
                        {
                            distance[nextNode] = distance[curNode] + cost;

                            if (j == N - 1)
                                return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}


