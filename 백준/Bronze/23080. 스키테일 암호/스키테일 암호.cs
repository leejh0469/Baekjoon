using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string s = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            int count = n;

            for(int i = 0; i < s.Length; i++)
            {
                if (count == n)
                {
                    sb.Append(s[i]);
                    count = 0;
                }
                count++;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}


