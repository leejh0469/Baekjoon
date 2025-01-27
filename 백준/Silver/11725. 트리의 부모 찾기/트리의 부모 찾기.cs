using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[N];
            bool[] isVisit = new bool[N];
            int[] parent = new int[N];

            for(int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < N - 1; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                graph[input[0] - 1].Add(input[1] - 1);
                graph[input[1] - 1].Add(input[0] - 1);
            }

            Queue<int> q = new Queue<int>();

            q.Enqueue(0);
            isVisit[0] = true;

            while (q.Count > 0)
            {
                int x = q.Dequeue();

                for(int i = 0; i < graph[x].Count; i++)
                {
                    if (!isVisit[graph[x][i]])
                    {
                        q.Enqueue(graph[x][i]);
                        isVisit[graph[x][i]] = true;
                        parent[graph[x][i]] = x;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < N; i++)
            {
                sb.Append(parent[i] + 1);
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}


