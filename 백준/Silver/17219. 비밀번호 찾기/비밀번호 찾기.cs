namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int N = input[0];
            int M = input[1];

            Dictionary<string, string> map = new Dictionary<string, string>();

            string[] inputs = new string[2];

            for(int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                map.Add(inputs[0], inputs[1]);
            }

            for(int i = 0; i < M; i++)
            {
                string s = Console.ReadLine();

                Console.WriteLine(map[s]);
            }
        }
    }
}
