namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            while(n > 0)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                int M = input[0]; // 가로
                int N = input[1]; // 세로
                int K = input[2]; // 배추 개수

                bool[,] isThereBaechu = new bool[N, M];
                bool[,] isVisit = new bool[N, M];

                for(int i = 0; i < K; i++)
                {
                    int[] inputXY = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                    isThereBaechu[inputXY[1], inputXY[0]] = true;
                }

                int count = 0;

                for(int i = 0; i < N; i++)
                {
                    for(int j = 0;  j < M; j++)
                    {
                        if (isVisit[i, j])
                            continue;

                        if(isThereBaechu[i, j])
                        {
                            DFS(isThereBaechu, isVisit, i, j);
                            count++;
                        }

                    }
                }

                Console.WriteLine(count);

                n--;
            }
        }

        static int[,] dir = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        static void DFS(bool[,] isThereBaechu, bool[,] isVisit, int i, int j)
        {
            isVisit[i, j] = true;

            for(int k = 0; k < 4; k++)
            {
                int y = i + dir[k, 0];
                int x = j + dir[k, 1];

                if ((x < 0 || x >= isThereBaechu.GetLength(1)) || (y < 0 || y >= isThereBaechu.GetLength(0)))
                    continue;

                if (isVisit[y, x])
                    continue;

                if(isThereBaechu[y, x])
                    DFS(isThereBaechu, isVisit, y, x);
            }
        }
    }
}
