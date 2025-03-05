namespace ConsoleApp1
{
    internal class Program
    {
        static public int Round(double x)
        {
            if (x % 1 >= 0.5)
                x += 1;

            return (int)x;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if(n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<int> list = new List<int>();

            for(int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            list.Sort();

            int round = Round((float)n * 15 / 100);

            long total = 0;

            for(int i = round; i < list.Count - round; i++)
            {
                total += list[i];
            }

            Console.WriteLine(Round((double)total / (list.Count - round * 2)));
        }
    }
}


