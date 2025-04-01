using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        public static long N, B;
        public static readonly int MOD = 1000;
        public static long[,] origin;

        static void Main(string[] args)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            N = input[0];
            B = input[1];

            origin = new long[N, N];

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

                for(int j = 0; j < N; j++)
                {
                    origin[i, j] = input[j] % MOD;
                }
            }

            long[,] result = DaC(origin, B);

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < N; i++)
            {
                for(int j = 0;j < N; j++)
                {
                    sb.Append(result[i,j] + " ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());

            long[,] DaC(long[,] matrix, long b)
            {
                if(b == 1)
                {
                    return matrix;
                }

                long[,] value = DaC(matrix, b / 2);

                value = Multiply(value, value);

                if(b % 2 == 1)
                {
                    value = Multiply(value, origin);
                }

                return value;
            }
        }

        public static long[,] Multiply(long[,] m1, long[,] m2)
        {
            long[,] result = new long[N, N];

            for(int i = 0; i < N; i++)
            {
                for(int j = 0;j < N; j++)
                {
                    for (int k = 0;k < N; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                        result[i, j] %= MOD;
                    }
                }
            }

            return result;
        }
    }
}
