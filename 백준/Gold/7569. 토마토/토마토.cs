using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    public struct Vector3
    {
        public int x;
        public int y;
        public int z;

        public Vector3(int z, int y, int x)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int N, M, H;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];
            H = input[2];

            int[,,] tomatos = new int[H, M, N];
            int[,,] distance = new int[H, M, N];
            bool[,,] visited = new bool[H, M, N];

            Queue<Vector3> q = new Queue<Vector3>();

            for(int i = 0; i < H; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                    for(int k = 0; k < N; k++)
                    {
                        tomatos[i, j, k] = input[k];
                        if (input[k] == 1)
                        {
                            q.Enqueue(new Vector3(i, j, k));
                            visited[i, j, k] = true;
                        }
                    }
                }
            }

            Vector3[] dir = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, -1, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

            while(q.Count > 0)
            {
                Vector3 curV = q.Dequeue();

                for(int i = 0; i < dir.Length; i++)
                {
                    Vector3 v = dir[i];

                    int nX = curV.x + v.x;
                    int nY = curV.y + v.y;
                    int nZ = curV.z + v.z;

                    if ((nX < 0 || nX >= N) || (nY < 0 || nY >= M) || (nZ < 0 || nZ >= H))
                        continue;

                    if (tomatos[nZ, nY, nX] == -1 || visited[nZ, nY, nX])
                        continue;

                    q.Enqueue(new Vector3(nZ, nY, nX));
                    visited[nZ, nY, nX] = true;
                    distance[nZ, nY, nX] = distance[curV.z, curV.y, curV.x] + 1;
                }
            }

            int max = 0;

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if(distance[i, j, k] == 0 && tomatos[i, j, k] == 0)
                        {
                            Console.WriteLine(-1);
                            return;
                        }
                        
                        if(distance[i, j, k] > max)
                            max = distance[i, j, k];
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}


