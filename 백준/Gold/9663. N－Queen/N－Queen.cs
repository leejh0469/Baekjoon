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
            int N = int.Parse(Console.ReadLine());

            int[] chessBoard = new int[N];

            int count = 0;

            dfs(0);

            Console.WriteLine(count);

            void dfs(int depth)
            {
                if(depth == N)
                {
                    count++;
                    return;
                }

                for(int i = 0; i < N; i++)
                {
                    if (checkQ(depth, i))
                    {
                        chessBoard[depth] = i;
                        dfs(depth + 1);
                        chessBoard[depth] = 0;
                    }
                }
            }

            bool checkQ(int depth, int index)
            {
                for(int i = depth - 1; i >= 0; i--)
                {
                    int y = i;
                    int x = chessBoard[i];

                    if (x == index || index - (depth - i) == x || index + (depth - i) == x)
                        return false;
                }

                return true;
            }
        }
    }
}


