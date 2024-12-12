namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int N = input[0];
            int M = input[1];
            int V = input[2];

            bool[,] graph = new bool[N, N];
            bool[] isVisit = new bool[N];

            List<int> d = new List<int>();

            for (int i = 0; i < M; i++)
            {
                int[] inputL = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                graph[inputL[0] - 1, inputL[1] - 1] = true;
                graph[inputL[1] - 1, inputL[0] - 1] = true;
            }

            dfs(graph, isVisit, V - 1, d);

            for (int i = 0; i < d.Count; i++)
            {
                Console.Write(d[i] + 1 + " ");
            }
            Console.WriteLine();

            for(int i = 0; i < N; i++)
            {
                isVisit[i] = false;
            }

            bfs(graph, isVisit, V - 1);
        }

        static void dfs(bool[,] graph, bool[] isVisit, int c, List<int> d)
        {
            isVisit[c] = true;

            d.Add(c);

            for(int i = 0; i < isVisit.Length; i++)
            {
                if (graph[c, i] && !isVisit[i] && c != i)
                {
                    dfs(graph, isVisit, i, d);
                }
            }
        }

        static void bfs(bool[,] graph, bool[] isVisit, int V)
        {
            List<int> b = new List<int>();

            Queue<int> q = new Queue<int>();

            q.Enqueue(V);
            isVisit[V] = true;

            while (q.Count > 0)
            {
                int x = q.Dequeue();

                b.Add(x);

                for (int i = 0; i < isVisit.Length; i++)
                {
                    if (graph[x, i] && !isVisit[i] && x != i)
                    {
                        q.Enqueue(i);
                        isVisit[i] = true;
                    }
                }
            }

            for (int i = 0; i < b.Count; i++)
            {
                Console.Write(b[i] + 1 + " ");
            }
            Console.WriteLine();
        }
    }
}