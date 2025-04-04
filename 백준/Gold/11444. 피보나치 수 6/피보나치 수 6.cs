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
        public static readonly int DIV = 1000000007;
        public static Dictionary<long, long> dic;

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            dic = new Dictionary<long, long>();

            dic.Add(0, 0);
            dic.Add(1, 1);

            Console.WriteLine(Fibonacci(n));
        }

        public static long Fibonacci(long n)
        {
            if (!dic.ContainsKey(n))
            {
                long fn = Fibonacci(n / 2);
                
                if (n % 2 == 0)
                {
                    long fnM1 = Fibonacci(n / 2 - 1);

                    dic[n] = (fn * (fn + 2 *  fnM1)) % DIV;
                }
                else
                {
                    long fnP1 = Fibonacci(n / 2 + 1);

                    dic[n] = (fn * fn + fnP1 * fnP1) % DIV;
                }
            }

            return dic[n];
        }
    }
}
