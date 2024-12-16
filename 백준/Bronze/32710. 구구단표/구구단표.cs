namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for(int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    if(i * j == N)
                    {
                        Console.WriteLine(1);
                        return;
                    }
                }
            }

            Console.WriteLine(0);
        }
    }
}
