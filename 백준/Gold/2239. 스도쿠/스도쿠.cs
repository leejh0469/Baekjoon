using System.Buffers;
using System.Security.AccessControl;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static int[,] sudoku = new int[9,9];

        static void Main(string[] args)
        {
            for(int i = 0; i < 9; i++)
            {
                int input = int.Parse(Console.ReadLine());
                int n = 10;

                for(int j = 8; j >= 0; j--)
                {
                    sudoku[i,j] = input % n;
                    input /= n;
                }
            }

            DFS(0, 0);
        }

        static void DFS(int y, int x)
        {
            if(y == 9)
            {
                PrintSudoku();
                Environment.Exit(0);
                return;
            }
            else
            {
                if (sudoku[y, x] == 0)
                {
                    for(int i = 0; i < 9; i++)
                    {
                        if(IsPossible(y, x, i + 1))
                        {
                            sudoku[y, x] = i + 1;
                            if (x == 8)
                                DFS(y + 1, 0);
                            else
                                DFS(y, x + 1);
                            sudoku[y, x] = 0;   
                        }
                    }
                }
                else
                {
                    if (x == 8)
                        DFS(y + 1, 0);
                    else
                        DFS(y, x + 1);
                }
            }
        }

        static bool IsPossible(int y, int x, int num)
        {
            int colY = (y / 3) * 3;
            int colX = (x / 3) * 3;

            for(int i = colY; i < colY + 3; i++)
            {
                for(int j = colX; j < colX + 3; j++)
                {
                    if (sudoku[i, j] == num)
                        return false;
                }
            }

            for(int i = 0; i < 9; i++)
            {
                if (sudoku[y, i] == num)
                    return false;

                if (sudoku[i, x] == num)
                    return false;
            }

            return true;
        }

        static void PrintSudoku()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sb.Append(sudoku[i, j]);
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }
    }
}
