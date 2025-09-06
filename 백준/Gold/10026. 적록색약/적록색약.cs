namespace ConsoleApp2
{
    internal class Program
    {
        public record Vector(int y, int x);

        public static int[,] direction = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string[] map = new string[N];

            for (int i = 0; i < N; i++)
            {
                map[i] = Console.ReadLine();
            }

            bool[,] visited = new bool[N, N];
            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!visited[i, j])
                    {
                        Queue<Vector> q = new Queue<Vector>();
                        q.Enqueue(new Vector(i, j));
                        visited[i, j] = true;

                        while (q.Count > 0)
                        {
                            Vector v = q.Dequeue();
                            int y = v.y;
                            int x = v.x;

                            for (int k = 0; k < 4; k++)
                            {
                                int nY = y + direction[k, 0];
                                int nX = x + direction[k, 1];

                                if (nY < 0 || nY >= N || nX < 0 || nX >= N)
                                    continue;

                                if (visited[nY, nX])
                                    continue;

                                if (map[nY][nX] == map[y][x])
                                {
                                    q.Enqueue(new Vector(nY, nX));
                                    visited[nY, nX] = true;
                                }
                            }
                        }

                        answer++;
                    }
                }
            }

            Console.Write(answer+ " ");
            answer = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    visited[i, j] = false;
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!visited[i, j])
                    {
                        Queue<Vector> q = new Queue<Vector>();
                        q.Enqueue(new Vector(i, j));
                        visited[i, j] = true;

                        while (q.Count > 0)
                        {
                            Vector v = q.Dequeue();
                            int y = v.y;
                            int x = v.x;

                            for (int k = 0; k < 4; k++)
                            {
                                int nY = y + direction[k, 0];
                                int nX = x + direction[k, 1];

                                if (nY < 0 || nY >= N || nX < 0 || nX >= N)
                                    continue;

                                if (visited[nY, nX])
                                    continue;

                                if (map[y][x] == 'B')
                                {
                                    if (map[nY][nX] == map[y][x])
                                    {
                                        q.Enqueue(new Vector(nY, nX));
                                        visited[nY, nX] = true;
                                    }
                                }
                                else
                                {
                                    if (map[nY][nX] != 'B')
                                    {
                                        q.Enqueue(new Vector(nY, nX));
                                        visited[nY, nX] = true;
                                    }
                                }
                            }
                        }

                        answer++;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
