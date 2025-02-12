using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public struct Pair
    {
        public int first;
        public int second;

        public Pair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int N, M;

            N = input[0];
            M = input[1];

            List<Pair> house = new List<Pair>();
            List<Pair> chicken = new List<Pair>();

            int[] chickenIndex = new int[M];

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0;  j < N; j++)
                {
                    if (input[j] == 1)
                    {
                        house.Add(new Pair(i, j));
                    }
                    else if(input[j] == 2)
                    {
                        chicken.Add(new Pair(i, j));
                    }
                }
            }

            int answer = int.MaxValue;

            dfs(0, -1);

            Console.WriteLine(answer);

            void dfs(int depth, int index)
            {
                if(depth == M)
                {
                    int total = 0;

                    for(int i = 0; i < house.Count; i++)
                    {
                        Pair p = house[i];
                        int x = p.second;
                        int y = p.first;

                        int min = int.MaxValue;

                        for(int j = 0; j < M; j++)
                        {
                            int ind = chickenIndex[j];

                            if(min > MathF.Abs(x - chicken[ind].second) + MathF.Abs(y - chicken[ind].first))
                            {
                                min = (int)(MathF.Abs(x - chicken[ind].second) + MathF.Abs(y - chicken[ind].first));
                            }
                        }

                        total += min;
                    }

                    if(answer > total)
                    {
                        answer = total;
                    }

                    return;
                }

                for(int i = index + 1; i < chicken.Count; i++)
                {
                    chickenIndex[depth] = i;
                    dfs(depth + 1, i);
                }
            }
        }
    }
}


