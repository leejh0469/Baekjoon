using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static readonly int INF = 10000000;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] bus = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i == j)
                        bus[i, j] = 0;
                    else
                        bus[i, j] = INF;
                }
            }

            int[] inputs;

            for(int i = 0; i < m; i++)
            {
                inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                bus[inputs[0] - 1, inputs[1] - 1] = (int)MathF.Min(bus[inputs[0] - 1, inputs[1] - 1], inputs[2]);
            }

            for(int i = 0; i < n; i++)
            {
                int x = i;

                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        if (j == k)
                            continue;

                        if (x == j || x == k)
                            continue;

                        if (bus[x, k] == INF || bus[j, x] == INF)
                            continue;

                        bus[j, k] = (int)MathF.Min(bus[j, k], bus[j, x] + bus[x, k]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < n; i++)
            {
                for(int j = 0;j < n; j++)
                {
                    if (bus[i, j] == INF)
                        bus[i, j] = 0;
                    sb.Append(bus[i, j] + " ");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}


