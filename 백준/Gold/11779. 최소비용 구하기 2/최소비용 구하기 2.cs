using System.Buffers;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            List<(int, int)>[] graph = new List<(int, int)>[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                graph[i] = new List<(int, int)>();
            }

            int[] input;

            for (int i = 0; i < m; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                graph[input[0]].Add((input[1], input[2]));
            }

            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int start = input[0];
            int end = input[1];

            int[] distance = new int[n + 1];
            int[] parent = new int[n + 1];
            bool[] visited = new bool[n + 1];

            for (int i = 1; i < n + 1; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                int close = int.MaxValue;
                int now = -1;

                for (int i = 1; i < n + 1; i++)
                {
                    if (visited[i])
                        continue;

                    if(distance[i] < close)
                    {
                        close = distance[i];
                        now = i;
                    }
                }

                if (now == -1)
                    break;

                visited[now] = true;

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int index = graph[now][i].Item1;

                    if(visited[index])
                        continue;

                    int calc = graph[now][i].Item2 + distance[now];

                    if(calc < distance[index])
                    {
                        distance[index] = calc;
                        parent[index] = now;
                    }
                }
            }

            List<int> path = new List<int>();

            int p = end;

            path.Add(p);

            while(p != start)
            {
                path.Add(parent[p]);
                p = parent[p];
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(distance[end].ToString());
            sb.AppendLine(path.Count.ToString());

            for(int i = path.Count - 1; i >= 0; i--)
            {
                sb.Append($"{path[i]} ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
