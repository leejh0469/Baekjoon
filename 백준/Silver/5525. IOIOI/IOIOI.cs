namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            string s = Console.ReadLine();

            int length = 1 + 2 * N;

            int[] table = new int[length + 1];
            char[] io = new char[length];

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                    io[i] = 'I';
                else
                    io[i] = 'O';
            }

            int total = 0;
            int count = 0;

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'O')
                    continue;

                while (i < s.Length - 2 && s[i + 1] == 'O' && s[i+2] == 'I')
                {
                    count++;
                    i+=2;
                }

                if (count >= N)
                    total += (count - N + 1);
                count = 0;
            }
            Console.WriteLine(total);
        }
    }
}


