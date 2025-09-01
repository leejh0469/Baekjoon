namespace Baekjoon18111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N, M, B;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            N = input[0];
            M = input[1];
            B = input[2];

            int[,] ground = new int[N, M];
            int maxHeight = -1;

            for(int i = 0; i < N; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);


                for(int j = 0; j < M; j++)
                {
                    ground[i, j] = input[j];

                    if (input[j] > maxHeight)
                        maxHeight = input[j];
                }
            }

            int time = int.MaxValue;
            int maxHeightWhenWorkDone = maxHeight;

            for(int i = maxHeight; i >= 0; i--)
            {
                int needBlockNum = 0;
                int haveBlockNum = B;

                for(int j = 0; j < N; j++)
                {
                    for(int k = 0;  k < M; k++)
                    {
                        needBlockNum += Math.Max(i - ground[j, k], 0);
                        haveBlockNum += Math.Max(ground[j, k] - i, 0);
                    }
                }

                if (needBlockNum > haveBlockNum)
                    continue;

                int calTime = 0;
                int workTimeForEachCoor;
                for(int j = 0; j < N; j++)
                {
                    for(int k = 0;k < M; k++)
                    {
                        workTimeForEachCoor = ground[j, k] - i;

                        if (workTimeForEachCoor > 0)
                        {
                            calTime += workTimeForEachCoor * 2;
                        }
                        else if(workTimeForEachCoor < 0)
                        {
                            calTime += Math.Abs(workTimeForEachCoor);
                        }
                    }
                }

                if (time > calTime)
                {
                    time = calTime;
                    maxHeightWhenWorkDone = i;
                }
            }

            Console.WriteLine(time + " " + maxHeightWhenWorkDone);
        }
    }
}