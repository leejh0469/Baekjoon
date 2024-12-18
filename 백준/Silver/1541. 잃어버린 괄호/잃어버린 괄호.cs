namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            List<int> nums = new List<int>();
            List<char> signs = new List<char>();

            signs.Add('+');

            int n = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-' || s[i] == '+')
                {
                    signs.Add(s[i]);
                    nums.Add(n);
                    n = 0;
                    continue;
                }

                n *= 10;
                n += s[i] - '0';

                if (i == s.Length - 1)
                {
                    nums.Add(n);
                    break;
                }
            }

            List<int> temps = new List<int>();

            int temp = 0;

            for(int i = 0; i < nums.Count;i++)
            {
                if (signs[i] == '-')
                {
                    temps.Add(temp);
                    temp = nums[i];
                }
                else
                {
                    temp += nums[i];
                }
            }

            temps.Add(temp);

            int total = temps[0];

            for(int i = 1; i < temps.Count; i++)
            {
                total -= temps[i];
            }

            Console.WriteLine(total);
        }
    }
}
