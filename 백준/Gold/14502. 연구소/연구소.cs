using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        public static int N, M;
        public static int max = 0;
        public static int[,] map;
        public static bool[,] visited;
        public static List<int> list;

        public static int[] yDir = { 0, -1, 0, 1 };
        public static int[] xDir = { 1, 0, -1, 0 };

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];

            map = new int[N, M];
            visited = new bool[N, M];

            list = new List<int>();

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < M; j++)
                {
                    map[i, j] = input[j];

                    if (input[j] == 2)
                    {
                        list.Add(M * i + j);
                    }
                }
            }

            DFS(0, 0);

            Console.WriteLine(max);
        }

        public static void DFS(int depth, int index)
        {
            // 벽 3개 다 쌓았을 때
            if(depth == 3)
            {
                // 최대 안전 구역 크기
                GetMax();
                return;
            }

            int x = index / M;
            int y = index % M;

            for(int i = x; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if (i == x && j < y)
                        continue;

                    if (map[i, j] == 0)
                    {
                        map[i, j] = 1;
                        DFS(depth + 1, i * M + j + 1);
                        map[i, j] = 0;
                    }
                }
            }
        }

        public static void GetMax()
        {
            for(int i = 0; i < N; i++)
            {
                for(int j = 0;j < M; j++)
                {
                    visited[i, j] = false;
                }
            }

            BFS();

            int count = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (!visited[i, j] && map[i, j] == 0)
                        count++;
                }
            }

            if(count > max)
                max = count;

        }

        public static void BFS()
        {
            Queue<int> q = new Queue<int>();

            for(int i = 0; i < list.Count; i++)
            {
                q.Enqueue(list[i]);
                visited[list[i] / M, list[i] % M] = true;
            }

            while(q.Count > 0)
            {
                int value = q.Dequeue();

                int y = value / M;
                int x = value % M;

                for(int i = 0; i < 4; i++)
                {
                    int nY = y + yDir[i];
                    int nX = x + xDir[i];

                    if(nY < 0 || nY >= N || nX < 0 || nX >= M)
                        continue;

                    if(visited[nY, nX])
                        continue;

                    if (map[nY, nX] == 0)
                    {
                        visited[nY, nX] = true;
                        q.Enqueue(nY * M + nX);
                    }
                }
            }
        }
    }
}
