using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static int N;
        static int lk, rk;
        static int max = 0;
        static int[] input;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());

            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            lk = 0;
            rk = 0;

            Dictionary<int, int> dic = new Dictionary<int, int>();

            while (rk < N && lk <= rk)
            {
                if(dic.Count <= 2)
                {
                    int key = input[rk];
                    if( dic.ContainsKey(key) )
                    {
                        dic[key]++;
                    }
                    else
                    {
                        dic.Add(key, 1);
                    }

                    if (dic.Count <= 2)
                        max = Math.Max(max, rk - lk + 1);

                    rk++;
                }
                else
                {
                    int key = input[lk];

                    dic[key]--;
                    if (dic[key] == 0)
                        dic.Remove(key);

                    lk++;
                }
            }

            Console.WriteLine(max);
        }
    }
}
