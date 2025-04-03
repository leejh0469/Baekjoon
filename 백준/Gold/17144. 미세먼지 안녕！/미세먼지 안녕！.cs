using System.Text;

namespace ConsoleApp2
{
    public struct Dust
    {
        public int value;
        public int y;
        public int x;

        public Dust(int value, int y, int x)
        {
            this.value = value;
            this.y = y;
            this.x = x;
        }
    }

    internal class Program
    {
        public static int R, C, T;
        public static int v1;
        public static int v2;
        public static int[,] map;

        public static int[] yDir = { 0, -1, 0, 1 };
        public static int[] xDir = { 1, 0, -1, 0 };

        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            R = input[0];
            C = input[1];
            T = input[2];

            map = new int[R, C];

            for(int i = 0; i < R; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < C; j++)
                {
                    map[i, j] = input[j];

                    if (input[j] == -1 && v1 == 0)
                    {
                        v1 = i;
                        v2 = i + 1;
                    }
                }
            }

            for(int i = 0; i < T; i++)
            {
                Spread();

                Ventilation();
            }

            int total = 0;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < R; i++)
            {
                for(int j = 0; j < C; j++)
                {
                    sb.Append(map[i, j] + " ");

                    if (map[i, j] == -1)
                        continue;

                    total += map[i, j];
                }

                sb.AppendLine();
            }

            Console.WriteLine(total);
        }

        public static void Spread()
        {
            List<Dust> list = new List<Dust>();

            for(int i = 0; i < R; i++)
            {
                for(int j = 0; j < C; j++)
                {
                    if (map[i, j] == -1)
                        continue;

                    if (map[i, j] < 5)
                        continue;

                    list.Add(new Dust(map[i, j], i, j));
                }
            }

            for(int i = 0; i < list.Count; i++)
            {
                int value = list[i].value;
                int y = list[i].y;
                int x = list[i].x;

                int spreadValue = value / 5;

                map[y, x] -= value;

                int total = 0;

                for(int j = 0; j < 4; j++)
                {
                    int nY = y + yDir[j];
                    int nX = x + xDir[j];

                    if (nY < 0 || nY >= R || nX < 0 || nX >= C || map[nY, nX] == -1)
                        continue;

                    map[nY, nX] += spreadValue;
                    total += spreadValue;
                }

                value -= total;

                map[y, x] += value;
            }
        }

        public static void Ventilation()
        {
            //윗공기 순환
            for(int i = v1 - 2; i >= 0; i--)
            {
                map[i + 1, 0] = map[i, 0];
            }

            for(int i = 1; i < C; i++)
            {
                map[0, i - 1] = map[0, i];
            }

            for(int i = 1; i <= v1; i++)
            {
                map[i - 1, C - 1] = map[i, C - 1];
            }

            for(int i = C - 2; i > 0; i--)
            {
                map[v1, i + 1] = map[v1, i];
            }


            //아랫공기 순환
            for(int i = v2 + 2; i < R; i++)
            {
                map[i - 1, 0] = map[i, 0];
            }

            for(int i = 1; i < C; i++)
            {
                map[R - 1, i - 1] = map[R - 1, i];
            }

            for(int i = R - 2; i >= v2; i--)
            {
                map[i + 1, C - 1] = map[i, C - 1];
            }

            for(int i = C - 2; i > 0; i--)
            {
                map[v2, i + 1] = map[v2, i];
            }

            //순환 후 공기가 배출된 인덱스의 남아있는 미세먼지 제거
            map[v1, 1] = 0;
            map[v2, 1] = 0;
        }
    }
}
