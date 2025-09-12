using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            int[] ary1 = new int[N + 1];

            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for(int i = 1; i <= N; i++)
            {
                ary1[i] = input[i - 1];
            }

            int M;

            M = int.Parse(Console.ReadLine());

            int[] ary2 = new int[M + 1];

            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int i = 1; i <= M; i++)

            {

                ary2[i] = input[i - 1];

            }

            if(N < M)
            {
                int[] temp = ary1;
                ary1 = ary2;
                ary2 = temp;

                int tempN = N;
                N = M;
                M = tempN;
            }

            int flag1 = 1;
            int flag2 = 1;  
            List<int> list = new List<int>();   

            while(flag1 <= N && flag2 <= M)
            {
                int max = -1;
                int coor1 = -1;
                int coor2 = -1;

                for(int i = flag1; i <= N; i++)
                {
                    for(int j = flag2; j <= M; j++)
                    {
                        if (ary1[i] == ary2[j])
                        {
                            if(max < ary1[i])
                            {
                                max = ary1[i];
                                coor1 = i;
                                coor2 = j;
                            }
                        }
                    }
                }

                if (coor1 == -1)
                    break;

                list.Add(max);
                flag1 = coor1 + 1;
                flag2 = coor2 + 1;
            }

            Console.WriteLine(list.Count());
            foreach (int i in list)
                Console.Write(i + " ");
        }
    }
}
