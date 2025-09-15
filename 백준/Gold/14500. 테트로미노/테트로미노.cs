using System.Buffers;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static int N, M;
        static int[,] map;
        static int max;
        static int[,] dir = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            N = input[0];
            M = input[1];

            map = new int[N, M];

            for(int i =0;i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                for(int j = 0;j < M; j++)
                {
                    map[i,j] = input[j];
                }
            }

            bool[,] visited = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    visited[i, j] = true;
                    DFS(i, j, 1, 0, visited);
                    visited[i, j] = false;
                    Check(i, j);
                }
            }

            Console.WriteLine(max);
        }

        static void DFS(int y, int x, int depth, int value, bool[,] visited)
        {
            value += map[y, x];

            if(depth == 4)
            {
                if(value > max)
                {
                    max = value;
                }
                return;
            }

            for(int i = 0; i < 4; i++)
            {
                int nY = y + dir[i, 0];
                int nX = x + dir[i, 1];

                if (nY < 0 || nY >= N || nX < 0 || nX >= M || visited[nY, nX])
                    continue;

                visited[nY, nX] = true;
                DFS(nY, nX, depth + 1, value, visited);
                visited[nY, nX] = false;
            }
        }

        static void Check(int y, int x)
        {
            if ((y == 0 && (x == 0 || x == M - 1)) || (y == N - 1 && (x == 0 || x == M - 1)))
                return;

            int value = map[y, x];

            if(y == 0)
            {
                value += map[y, x - 1];
                value += map[y, x + 1];
                value += map[y + 1, x];
            }
            else if(y == N - 1)
            {
                value += map[y - 1, x]; 
                value += map[y, x - 1];
                value += map[y, x + 1];
            }
            else if(x == 0)
            {
                value += map[y, x + 1];
                value += map[y - 1, x];
                value += map[y + 1, x];
            }
            else if(x == M - 1)
            {
                value += map[y, x - 1];
                value += map[y - 1, x];
                value += map[y + 1, x];
            }
            else
            {
                int min = 1001;
                for(int i = 0; i < 4; i++)
                {
                    value += map[y + dir[i, 0], x + dir[i, 1]];
                    if (min > map[y + dir[i, 0], x + dir[i, 1]])
                        min = map[y + dir[i, 0], x + dir[i, 1]];
                }

                value -= min;
            }

            if(max < value)
                max = value;
        }
    }
}
