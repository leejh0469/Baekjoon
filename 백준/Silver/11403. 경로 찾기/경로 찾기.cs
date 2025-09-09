using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] graph = new int[N, N];

            for(int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                for(int j = 0; j < N; j++)
                {
                    graph[i, j] = input[j];
                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < N; i++)
            {
                int[] visited = new int[N];
                Queue<int> q = new Queue<int>();

                for(int j = 0; j < N; j++)
                {
                    if (graph[i, j] == 1)
                    {
                        q.Enqueue(j);
                        visited[j]++;
                    }
                }

                while(q.Count > 0)
                {
                    int x = q.Dequeue();

                    for (int j = 0; j < N; j++)
                    {
                        if (graph[x, j] == 1 && visited[j] == 0)
                        {
                            q.Enqueue(j);
                            visited[j]++;
                        }
                    }
                }

                for(int j = 0; j < N; j++)
                {
                    sb.Append(visited[j] + " ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
