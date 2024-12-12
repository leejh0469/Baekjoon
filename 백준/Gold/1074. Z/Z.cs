namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int N = input[0];
            int r = input[2];
            int c = input[1];

            int s = 1;

            for(int i = 0; i < N; i++)
            {
                s *= 2;
            }

            int total = 0;

            for(int i = 0; i < N; i++)
            {
                int k;

                if(c >= s / 2)
                {
                    if (r >= s / 2)
                    {
                        k = 3;
                        r -= s / 2;
                        c -= s / 2;
                    }
                    else
                    {
                        k = 2;
                        c -= s / 2;
                    }
                }
                else
                {
                    if (r >= s / 2)
                    {
                        k = 1;
                        r -= s / 2;
                    }
                    else
                        k = 0;
                }

                total += (s / 2) * (s / 2) * k;

                s /= 2;
            }

            Console.WriteLine(total);
        }
    }
}
