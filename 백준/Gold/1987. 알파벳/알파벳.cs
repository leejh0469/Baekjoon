using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static int max = 0;

        public static int[] xDir = { 1, 0, -1, 0 };
        public static int[] yDir = { 0, -1, 0, 1 };

        static void Main(string[] args)
        {
            int R, C;

            string[] input = Console.ReadLine().Split(' ');

            R = int.Parse(input[0]);
            C = int.Parse(input[1]);

            char[,] map = new char[R, C];
            bool[] alpha = new bool[26];

            for(int i = 0; i < R; i++)
            {
                string s = Console.ReadLine();

                for(int j = 0; j < C; j++)
                {
                    map[i, j] = s[j];
                }
            }

            DFS(1, alpha, map, 0, 0);

            Console.WriteLine(max);
        }

        public static void DFS(int depth, bool[] alpha, char[,] map, int y, int x)
        {
            alpha[map[y, x] - 65] = true;

            for(int i = 0; i < 4; i++)
            {
                int nextY = y + yDir[i];
                int nextX = x + xDir[i];

                if(nextY < 0 || nextY >= map.GetLength(0) || nextX < 0 || nextX >= map.GetLength(1))
                    continue;

                if (!alpha[map[nextY, nextX] - 65])
                {
                    DFS(depth + 1, alpha, map, nextY, nextX);
                }
            }

            if(depth > max)
                max = depth;

            alpha[map[y, x] - 65] = false;
        }
    }
}
