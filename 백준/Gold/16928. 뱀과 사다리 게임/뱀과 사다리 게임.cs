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
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            N = input[0];
            M = input[1];

            int[] map = new int[101];

            for(int i = 0; i <= 100; i++)
            {
                map[i] = i;
            }

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                map[input[0]] = map[input[1]];
            }

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                map[input[0]] = map[input[1]];
            }

            bool[] visited = new bool[101];
            int[] distance = new int[101];
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            visited[1] = true;
            distance[1] = 0;

            while(q.Count > 0)
            {
                int current = q.Dequeue();

                for(int i = 0; i < 6; i++)
                {
                    if (current + i + 1 > 100)
                        break;
                    

                    int next = map[current + i + 1];

                    if(!visited[next])
                    {
                        visited[next] = true;
                        distance[next] = distance[current] + 1;

                        if (next == 100)
                            break;

                        q.Enqueue(next);
                    }
                }
            }

            Console.WriteLine(distance[100]);
        }
    }
}
