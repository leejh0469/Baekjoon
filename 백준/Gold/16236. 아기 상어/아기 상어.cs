using System.Text;

namespace ConsoleApp1
{
    public record Vector(int y, int x);

    internal class Program
    {
        public static int[,] direction = { { -1, 0 }, { 0, -1 }, { 0, 1 }, { 1, 0 } };

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] graph = new int[N, N];
            int[,] distance = new int[N, N];

            Vector startPos = new Vector(-1, -1);

            for (int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                for (int j = 0; j < N; j++)
                {
                    graph[i, j] = input[j];
                    if (input[j] == 9)
                    {
                        startPos = new Vector(i, j);
                        graph[i, j] = 0;
                    }
                }
            }

            int eatNum = 0;
            int size = 2;
            int answer = 0;

            while (true)
            {
                //매번 시작 위치에서 가장 가까운 물고기로 이동해야함
                //이동하기 위해 매번 bfs 실행
                //이동할 물고기가 없다면 break;

                //시작 전 거리 리셋
                for(int i = 0; i < N; i++)
                {
                    for(int j = 0; j < N; j++)
                    {
                        distance[i, j] = -1;
                    }
                }

                List<Vector> list = new List<Vector>();

                Queue<Vector> q = new Queue<Vector>();
                q.Enqueue(startPos);
                distance[startPos.y, startPos.x] = 0;

                //bfs
                while(q.Count > 0)
                {
                    Vector v = q.Dequeue();

                    //4방향 탐색
                    for(int i = 0; i < 4; i++)
                    {
                        int nY = v.y + direction[i, 0];
                        int nX = v.x + direction[i, 1];

                        if (nY < 0 || nY >= N || nX < 0 || nX >= N || distance[nY, nX] != -1)
                            continue;

                        if (graph[nY, nX] > size)
                            continue;

                        q.Enqueue(new Vector(nY, nX));
                        distance[nY, nX] = distance[v.y, v.x] + 1;

                        if (graph[nY, nX] < size && graph[nY, nX] > 0)
                        {
                            list.Add(new Vector(nY, nX));
                        }
                    }
                }

                //더이상 먹을 물고기가 없다면 탐색 끝
                if (list.Count == 0)
                    break;

                //먹을 수 있는 물고기 리스트 정렬
                //거리순
                //y축 순
                //x축 순 오름차순 정렬
                startPos = list.OrderBy(v => distance[v.y, v.x]).
                    ThenBy(v => v.y).
                    ThenBy(v => v.x).
                    First();

                answer += distance[startPos.y, startPos.x];

                //Console.WriteLine(startPos);

                graph[startPos.y, startPos.x] = 0;
                eatNum++;
                if(eatNum == size)
                {
                    eatNum = 0;
                    size++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
