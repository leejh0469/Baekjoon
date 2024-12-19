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
            
            for(int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                    io[i] = 'I';
                else
                    io[i] = 'O';
            }
            
            table[0] = -1;
            table[1] = 0;
            for(int i = 2; i < length + 1; i++)
            {
                if(i % 2 == 1)
                {
                    table[i] = i - 2;
                }
                else
                {
                    table[i] = 0;
                }
            }

            int flag = 0;
            int total = 0;

            while(flag <= s.Length - length)
            {
                int matchLength = 0;

                for(int i = 0; i < length; i++)
                {
                    if (s[flag + i] != io[i])
                    {
                        break;
                    }
                    matchLength++;
                }

                flag += (matchLength - table[matchLength]);

                if (matchLength == length)
                    total++;
            }

            Console.WriteLine(total);
        }
    }
}


