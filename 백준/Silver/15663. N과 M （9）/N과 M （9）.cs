using System;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void dfs(int[] x, int[] seq, int i, int index, int N, int M, bool[] use)
        {
            use[i] = true;
            seq[index] = x[i];

            if(index == M - 1)
            {
                StringBuilder sb = new StringBuilder();

                for(int j = 0; j < M; j++)
                {
                    sb.Append(seq[j] + " ");

                }

                Console.WriteLine(sb.ToString());
                return;
            }

            int tmp = 0;
            for(int j = 0; j < N; j++)
            {
                if (j == i)
                    continue;
                if (tmp == x[j])
                    continue;
                if (use[j])
                    continue;

                tmp = x[j];
                dfs(x, seq, j, index + 1, N, M, use);
                use[j] = false;
            }
        }

        static void Main(string[] args)
        {
            int N, M;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];

            int[] x = new int[N];

            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for(int i = 0; i < N; i++)
            {
                x[i] = input[i];
            }

            Array.Sort(x);

            int[] seq = new int[M];
            bool[] use = new bool[N];

            for(int i = 0; i < N; i++)
            {
                if (seq[0] == x[i])
                    continue;

                dfs(x, seq, i, 0, N, M, use);
                use[i] = false;
            }
        }
    }
}


