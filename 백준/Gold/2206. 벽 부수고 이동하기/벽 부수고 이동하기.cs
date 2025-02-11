using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static readonly int[,] dir = {{1, 0}, {0, -1}, {-1, 0}, {0, 1}};

        public struct Path
        {
            public int x;
            public int y;
            public int distance;
            public int wall;

            public Path(int x, int y, int distance, int wall)
            {
                this.x = x;
                this.y = y;
                this.distance = distance;
                this.wall = wall;
            }
        }

        static void Main(string[] args)
        {
            int n, m;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            n = input[0];
            m = input[1];

            int[,] map = new int[n, m];
            bool[,,] visited = new bool[n, m, 2];

            int answer = -1;

            for(int i = 0; i < n; i++)
            {
                string inputS = Console.ReadLine();

                for(int j = 0; j < m; j++)
                {
                    map[i, j] = inputS[j] - '0';
                }
            }

            bfs();

            Console.WriteLine(answer);

            void bfs()
            {
                Queue<Path> q = new Queue<Path>();

                q.Enqueue(new Path(0, 0, 1, 0));

                visited[0, 0, 0] = true;

                while(q.Count > 0)
                {
                    Path p = q.Dequeue();

                    if(p.y == n - 1 && p.x == m - 1)
                    {
                        answer = p.distance;
                        break;
                    }

                    for(int i = 0; i < 4; i++)
                    {
                        int nextY = p.y + dir[i, 1];
                        int nextX = p.x + dir[i, 0];

                        if(nextY < 0 || nextX < 0 || nextY >= n || nextX >= m)
                            continue;

                        if (map[nextY, nextX] == 1 && p.wall == 0 && !visited[nextY, nextX, p.wall])
                        {
                            q.Enqueue(new Path(nextX, nextY, p.distance + 1, p.wall + 1));
                            visited[nextY, nextX, p.wall] = true;
                        }
                        else if (map[nextY, nextX] == 0 && !visited[nextY, nextX, p.wall])
                        {
                            q.Enqueue(new Path(nextX, nextY, p.distance + 1, p.wall));
                            visited[nextY, nextX, p.wall] = true;
                        }
                    }
                }
            }
        }
    }
}


