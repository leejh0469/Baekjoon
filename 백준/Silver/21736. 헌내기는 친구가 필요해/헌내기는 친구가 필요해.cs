namespace ConsoleApp1
{
    internal class Program
    {
        public struct Vector
        {
            public int y;
            public int x;

            public Vector(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

        static int[,] direction = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        static void Main(string[] args)
        {
            int N, M;

            string input = Console.ReadLine();

            var s = input.Split();

            N = int.Parse(s[0]);
            M = int.Parse(s[1]);

            char[,] map = new char[N, M];
            bool[,] visited = new bool[N, M];

            int startX = -1;
            int startY = -1;

            for(int i = 0; i < N; i++)
            {
                input = Console.ReadLine();

                for(int j = 0; j < M; j++)
                {
                    map[i, j] = input[j];
                    visited[i, j] = false;

                    if (map[i,j] == 'I')
                    {
                        startX = j;
                        startY = i;
                    }
                }
            }

            Queue<Vector> q = new Queue<Vector>();

            visited[startY, startX] = true;
            q.Enqueue(new Vector(startY, startX));

            while(q.Count > 0)
            {
                Vector v = q.Dequeue();

                int y = v.y;
                int x = v.x;

                for(int i = 0; i < 4; i++)
                {
                    int nextY = y + direction[i, 0];
                    int nextX = x + direction[i, 1];

                    if((nextY < 0 || nextY >= N) || (nextX < 0 || nextX >= M))
                        continue;

                    if (visited[nextY, nextX] == true)
                        continue;

                    if (map[nextY, nextX] == 'X')
                        continue;

                    visited[nextY, nextX] = true;
                    q.Enqueue(new Vector(nextY, nextX));
                }
            }

            int count = 0;

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if (visited[i,j] == true && map[i, j] == 'P')
                        count++;
                }
            }

            Console.WriteLine((count == 0) ? "TT" : count);
        }
    }
}
