namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Console.Write("The largest square has side length " + (int)MathF.Sqrt(N) + ".");
        }
    }
}


