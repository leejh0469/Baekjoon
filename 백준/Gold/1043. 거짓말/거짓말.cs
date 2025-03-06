using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int N, M;

            N = input[0];
            M = input[1];

            int[] parent = new int[N + 1];

            for(int i = 0; i <= N; i++)
            {
                parent[i] = i;
            }

            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            for(int i = 0; i < input[0]; i++)
            {
                parent[input[i + 1]] = 0;
            }

            List<int>[] parties = new List<int>[M];
            int[] partyNum = new int[M];

            for(int i = 0; i < M; i++)
            {
                parties[i] = new List<int>();
            }

            for(int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int num = input[0];

                
                parties[i].Add(input[1]);

                for(int j = 1; j < num; j++)
                {
                    parties[i].Add(input[j + 1]);
                    Union(input[1], input[j + 1]);
                }
            }

            int answer = M;

            for(int i = 0; i < M; i++)
            {
                for(int j = 0; j < parties[i].Count; j++)
                {
                    if (Find(parties[i][j]) == 0)
                    {
                        answer--;
                        break;
                    }
                }
            }

            Console.WriteLine(answer);

            int Find(int x)
            {
                if (x != parent[x])
                    return parent[x] = Find(parent[x]);

                return parent[x];
            }

            void Union(int x, int y)
            {
                int a = Find(x);
                int b = Find(y);

                if(a < b)
                    parent[b] = parent[a];
                else
                    parent[a] = parent[b];
            }
        }
    }
}


