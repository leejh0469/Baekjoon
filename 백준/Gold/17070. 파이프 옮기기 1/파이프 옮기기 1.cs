using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static int answer = 0;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] graph = new int[N, N];

            for(int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < N; j++)
                {
                    graph[i, j] = input[j];
                }
            }

            // 0 - 가로, 1 - 대각선, 2 - 세로
            dfs(1, 0, 0);

            Console.WriteLine(answer);

            void dfs(int x, int y, int state)
            {
                if(x == N - 1 && y == N - 1)
                {
                    answer++;
                    return;
                }

                switch (state)
                {
                    case 0:
                        if(x + 1 < N && canMove(x + 1, y, 0))
                            dfs(x + 1, y, 0);
                        if (x + 1 < N && y + 1 < N && canMove(x + 1, y + 1, 1))
                            dfs(x + 1, y + 1, 1);
                        break;
                    case 1:
                        if (x + 1 < N && canMove(x+1, y, 0))
                            dfs(x + 1, y, 0);
                        if (x + 1 < N && y + 1 < N && canMove(x + 1, y + 1, 1))
                            dfs(x + 1, y + 1, 1);
                        if(y + 1 < N && canMove(x, y + 1, 2))
                            dfs(x, y + 1, 2);
                        break;
                    case 2:
                        if (y + 1 < N && canMove(x, y + 1, 2))
                            dfs(x, y + 1, 2);
                        if(x + 1 < N && y + 1 < N && canMove(x + 1, y + 1, 1))
                            dfs(x+ 1, y+1, 1);
                        break;
                }
            }

            bool canMove(int x, int y, int state)
            {
                bool canMove = false;

                switch (state)
                {
                    case 0:
                        if (graph[y, x] != 1)
                            canMove = true;
                        break;
                    case 1:
                        if (graph[y, x] != 1 && graph[y - 1, x] != 1 && graph[y, x - 1] != 1)
                            canMove = true;
                        break;
                    case 2:
                        if (graph[y, x] != 1)
                            canMove = true;
                        break;
                }

                return canMove;
            }
        }
    }
}


