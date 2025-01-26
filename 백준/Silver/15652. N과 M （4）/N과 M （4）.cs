using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void DFS(List<int> list, int i, int N, int M)
        {
            list.Add(i);

            if(list.Count == M)
            {
                StringBuilder sb = new StringBuilder();

                for(int j = 0; j < list.Count; j++)
                {
                    sb.Append(list[j] + " ");
                }

                Console.WriteLine(sb.ToString());
                list.RemoveAt(list.Count - 1);  

                return;
            }

            for(int j = i; j <= N; j++)
            {
                DFS(list, j, N, M);
            }

            list.RemoveAt(list.Count - 1);
        }

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int N = input[0];
            int M = input[1];

            List<int> list = new List<int>();

            for(int i = 0; i < N; i++)
            {
                DFS(list, i + 1, N, M);
            }
        }
    }
}


