namespace Backjoon11365
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                char[] s = input.ToArray();
                if (input == "END")
                    break;
                Array.Reverse(s);
                Console.WriteLine(s);
            }
        }
    }
}