using System.Buffers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N, M;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            N = input[0];
            M = input[1];

            int[] nums;
            int[] seq = new int[M];

            nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(nums);

            StringBuilder sb = new StringBuilder();

            dfs(0, 0);
            Console.WriteLine(sb.ToString());

            void dfs(int depth, int x)
            {
                if (depth == M)
                {
                    for(int i = 0; i < M; i++)
                    {
                        sb.Append(seq[i] + " ");
                    }
                    sb.Append("\n");

                    return;
                }

                int value = 0;

                for(int i = 0; i < N; i++)
                {
                    if (nums[i] < x)
                        continue;

                    if (value == nums[i])
                        continue;

                    value = nums[i];
                    seq[depth] = nums[i];
                    dfs(depth + 1, nums[i]);
                }
            }
        }
    }
}


