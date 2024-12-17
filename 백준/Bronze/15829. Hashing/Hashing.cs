namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string s = Console.ReadLine();

            long total = 0;
            long x = 1;

            for(int i = 0; i < N; i++)
            {
                total += (s[i] - 96) * x;

                x *= 31;
            }

            Console.WriteLine(total % 1234567891);
        }
    }
}
