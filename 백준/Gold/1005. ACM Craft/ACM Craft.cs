namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            while (T > 0)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int N, K;

                N = input[0];
                K = input[1];

                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] constructTime = new int[N + 1];

                for (int i = 1; i <= N; i++)
                {
                    constructTime[i] = input[i - 1];
                }

                List<int>[] graph = new List<int>[N + 1];
                int[] inDegree = new int[N + 1];
                int[] time = new int[N + 1];

                for (int i = 0; i <= N; i++)
                {
                    graph[i] = new List<int>();
                }

                for (int i = 0; i < K; i++)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                    graph[input[0]].Add(input[1]);

                    inDegree[input[1]]++;
                }

                PriorityQueue<int, int> q = new PriorityQueue<int, int>();

                for (int i = 1; i <= N; i++)
                {
                    if (inDegree[i] == 0)
                    {
                        time[i] = constructTime[i];
                        q.Enqueue(i, time[i]);
                    }
                }

                for (int i = 1; i <= N; i++)
                {
                    if (q.Count == 0)
                    {
                        return;
                    }

                    int cur = q.Dequeue();

                    for (int j = 0; j < graph[cur].Count; j++)
                    {
                        if (--inDegree[graph[cur][j]] == 0)
                        {
                            time[graph[cur][j]] = time[cur] + constructTime[graph[cur][j]];
                            q.Enqueue(graph[cur][j], time[graph[cur][j]]);
                        }
                    }
                }

                int W = int.Parse(Console.ReadLine());

                Console.WriteLine(time[W]);

                T--;
            }
        }
    }
}
