using System.Text;

namespace ConsoleApp1
{
    public record Vector(int y, int x);

    internal class Program
    {
        public static int[,] direction = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        static int N, M;
        static int[,] map;
        static bool noAir = false;

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            N = input[0];
            M = input[1];

            map = new int[N, M];
                 
            for(int i = 0; i  < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                for(int j = 0; j < M; j++)
                {
                    map[i, j] = input[j];
                }
            }

            int answer = 0;

            while (IsAnyCheese())
            {
                // 갇힌 공기 확인
                if(!noAir)
                    CheckAir();

                // 치즈 녹이기
                Melting();

                answer++;
            }

            Console.WriteLine(answer);
        }

        static void CheckAir()
        {
            //BFS로 공기 묶음
            //치즈 안 공기는 map 값을 2 배수로 변경

            bool[,] visited = new bool[N, M];
            Queue<Vector> q = new Queue<Vector>();
            q.Enqueue(new Vector(0, 0));
            visited[0, 0] = true;

            while (q.Count > 0)
            {
                Vector v = q.Dequeue();

                for (int k = 0; k < 4; k++)
                {
                    int nY = v.y + direction[k, 0];
                    int nX = v.x + direction[k, 1];

                    if (nY < 0 || nY >= N || nX < 0 || nX >= M || visited[nY, nX])
                        continue;

                    if (map[nY, nX] != 1)
                    {
                        q.Enqueue(new Vector(nY, nX));
                        visited[nY, nX] = true;
                        map[nY, nX] = 0;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if (map[i, j] == 0 && !visited[i, j])
                        map[i, j] = -1;
                }
            }
        }

        static bool IsAnyCheese()
        {
            for(int i = 0; i < N; i++)
            {
                for(int j = 0;  j < M; j++)
                {
                    if (map[i, j] == 1)
                        return true;
                }
            }

            return false;
        }

        static void Melting()
        {
            List<Vector> list = new List<Vector>();

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j <  M; j++)
                {
                    if(map[i, j] == 1)
                    {
                        int side = 0;

                        for(int k = 0; k < 4; k++)
                        {
                            int nY = i + direction[k, 0];
                            int nX = j + direction[k, 1];

                            if (nY < 0 || nY >= N || nX < 0 || nX >= M)
                                continue;

                            if (map[nY, nX] == 0)
                                side++;
                        }

                        if (side >= 2)
                            list.Add(new Vector(i, j));
                    }
                }
            }

            for(int i = 0; i < list.Count; i++)
            {
                map[list[i].y, list[i].x] = 0;
            }
        }
    }
}
