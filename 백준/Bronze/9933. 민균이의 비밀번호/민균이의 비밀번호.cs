using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string[] s = new string[N];
            string[] reverse = new string[N];

            for (int i = 0; i < N; i++)
            {
                s[i] = Console.ReadLine();
                reverse[i] = new string(s[i].Reverse().ToArray());
            }

            for(int i = 0; i < N; i++)
            {
                for(int j = i; j < N; j++)
                {
                    if(reverse[i] == s[j])
                    {
                        int index = reverse[j].Length / 2;
                        Console.WriteLine(reverse[j].Length + " " + reverse[j][index]);
                    }
                }
            }
        }
    }
}


