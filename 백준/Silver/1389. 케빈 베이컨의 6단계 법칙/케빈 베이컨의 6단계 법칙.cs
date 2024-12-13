namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int N = input[0];
            int M = input[1];

            bool[,] graph = new bool[N, N];
            bool[] isVisit = new bool[N];

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                graph[input[0] - 1, input[1] - 1] = true;
                graph[input[1] - 1, input[0] - 1] = true;
            }

            int[] kevin = new int[N];

            for(int i = 0; i < N; i++)
            {
                int[] distance = new int[N];

                for (int j = 0; j < N; j++)
                {
                    isVisit[j] = false;
                }

                bfs(graph, isVisit, i, distance);

                for (int j = 0; j < N; j++)
                {
                    kevin[i] += distance[j];
                }
            }

            int min = 0;

            for (int i = 1; i < N; i++)
            {
                if (kevin[min] > kevin[i])
                    min = i;
            }

            Console.WriteLine(min + 1);
        }

        static void bfs(bool[,] graph, bool[] isVisit, int V, int[] distance)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(V);
            isVisit[V] = true;

            while(q.Count > 0)
            {
                int x = q.Dequeue();

                for(int i = 0; i < isVisit.Length; i++)
                {
                    if (graph[x, i] && !isVisit[i] && x != i)
                    {
                        q.Enqueue(i);
                        isVisit[i] = true;
                        distance[i] = distance[x] + 1;
                    }
                }
            }
        }
    }
}
