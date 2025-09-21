using System.Buffers;
using System.Security.AccessControl;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static int[,] sudoku = new int[9,9];
        static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static List<int[,]> answers = new List<int[,]>();
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

            DFS();

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    sb.Append(answers[0][i, j]);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        static void DFS()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        List<int> list = GetPosibleNum(i, j);

                        if (list.Count == 0)
                            return;

                        for(int k = 0; k < list.Count; k++)
                        {
                            sudoku[i, j] = list[k];
                            DFS();
                            sudoku[i, j] = 0;
                        }

                        return;
                    }
                }
            }

            PrintSudoku();
            Environment.Exit(0);
            return;
        }

        static List<int> GetPosibleNum(int y, int x)
        {
            List<int> value = new List<int>();
            for(int i = 0; i < 9; i++)
            {
                value.Add(i + 1);
            }

            int colY = (y / 3) * 3;
            int colX = (x / 3) * 3;

            for(int i = colY; i < colY + 3; i++)
            {
                for(int j = colX; j < colX + 3; j++)
                {
                    if (sudoku[i, j] != 0)
                        value.Remove(sudoku[i, j]);
                }
            }

            for(int i = 0; i < 9; i++)
            {
                if (sudoku[y, i] != 0)
                    value.Remove(sudoku[y, i]);

                if (sudoku[i, x] != 0)
                    value.Remove(sudoku[i, x]);
            }

            return value;
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
