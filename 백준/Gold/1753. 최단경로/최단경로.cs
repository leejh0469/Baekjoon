using System.Buffers;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public struct Path
    {
        public int index;
        public int distance;

        public Path(int index, int distance)
        {
            this.index = index;
            this.distance = distance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int V, E;

            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            
            V = inputs[0];
            E = inputs[1];

            int K = int.Parse(Console.ReadLine()) - 1;

            List<Path>[] graph = new List<Path>[V];
            for(int i = 0; i < V; i++)
            {
                graph[i] = new List<Path>();
            }

            int[] distance = new int[V];
            Array.Fill(distance, Int32.MaxValue);
            int[] parent = new int[V];  

            bool[] isVisit = new bool[V];
            bool[] isLink = new bool[V];

            for(int i = 0; i < E; i++)
            {
                inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                bool isAlt = false;

                for(int j = 0; j < graph[inputs[0] - 1].Count; j++)
                {
                    if (graph[inputs[0] - 1][j].index == inputs[1] - 1)
                    {
                        isAlt = true;

                        if(graph[inputs[0] - 1][j].distance > inputs[2])
                        {
                            graph[inputs[0] - 1][j] = new Path(inputs[1] - 1, inputs[2]);
                        }
                    }
                }

                if(!isAlt)
                    graph[inputs[0] - 1].Add(new Path(inputs[1] - 1, inputs[2]));
            }

            distance[K] = 0;
            parent[K] = K;
            isLink[K] = true;

            while (true)
            {
                int close = Int32.MaxValue;
                int now = -1;

                for(int i = 0; i < V; i++)
                {
                    if (isVisit[i])
                        continue;

                    if (distance[i] == Int32.MaxValue || distance[i] >= close)
                        continue;

                    close = distance[i];
                    now = i;
                }

                if (now == -1)
                    break;

                isVisit[now] = true;

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int index = graph[now][i].index;

                    if (isVisit[index])
                        continue;

                    int calculatedDistance = graph[now][i].distance + distance[now];

                    if(calculatedDistance < distance[index])
                    {
                        distance[index] = calculatedDistance;
                        parent[index] = now;
                        if (isLink[now])
                        {
                            isLink[index] = true;
                        }
                    }

                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < V; i++)
            {
                if (!isLink[i])
                {
                    sb.Append("INF");
                }
                else
                {
                    sb.Append(distance[i]);
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }


    }
}


