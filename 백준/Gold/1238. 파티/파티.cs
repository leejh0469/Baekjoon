using System.ComponentModel;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static readonly int INF = 10000001;

        public struct Path
        {
            public int index;
            public int cost;

            public Path(int index, int cost)
            {
                this.index = index;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            int N, M, X;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];
            X = input[2] - 1;

            List<Path>[] dir = new List<Path>[N];
            List<Path>[] revDir = new List<Path>[N];

            int[] distance = new int[N];
            int[] revDistance = new int[N];

            bool[] isVisit = new bool[N];

            Array.Fill(distance, INF);
            Array.Fill(revDistance, INF);

            for(int i = 0; i < N; i++)
            {
                dir[i] = new List<Path>();
                revDir[i] = new List<Path>();
            }

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                dir[input[0] - 1].Add(new Path(input[1] - 1,  input[2]));
                revDir[input[1] - 1].Add(new Path(input[0] - 1, input[2]));
            }

            distance[X] = 0;

            while (true)
            {
                int close = INF;
                int now = -1;

                for(int i = 0; i < N; i++)
                {
                    if (isVisit[i])
                        continue;

                    if (distance[i] == INF || distance[i] >= close)
                        continue;

                    close = distance[i];
                    now = i;
                }

                if (now == -1)
                    break;

                isVisit[now] = true;

                for(int i = 0; i < dir[now].Count; i++)
                {
                    int index = dir[now][i].index;

                    if (isVisit[index])
                        continue;

                    int calculateDistance = dir[now][i].cost + distance[now];

                    if(calculateDistance < distance[index])
                    {
                        distance[index] = calculateDistance;
                    }
                }
            }

            Array.Fill(isVisit, false);

            revDistance[X] = 0;

            while (true)
            {
                int close = INF;
                int now = -1;

                for (int i = 0; i < N; i++)
                {
                    if (isVisit[i])
                        continue;

                    if (revDistance[i] == INF || revDistance[i] >= close)
                        continue;

                    close = revDistance[i];
                    now = i;
                }

                if (now == -1)
                    break;

                isVisit[now] = true;

                for (int i = 0; i < revDir[now].Count; i++)
                {
                    int index = revDir[now][i].index;

                    if (isVisit[index])
                        continue;

                    int calculateDistance = revDir[now][i].cost + revDistance[now];

                    if (calculateDistance < revDistance[index])
                    {
                        revDistance[index] = calculateDistance;
                    }
                }
            }

            int maxDistance = 0;

            for(int i = 0; i < N; i++)
            {
                if (distance[i] + revDistance[i] > maxDistance)
                    maxDistance = distance[i] + revDistance[i];
            }

            Console.WriteLine(maxDistance);
        }
    }
}


