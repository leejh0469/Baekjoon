namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            while(N-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                Dictionary<string, int> dict = new Dictionary<string, int>();

                for(int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine().Split(' ');

                    if (dict.ContainsKey(input[1]))
                    {
                        dict[input[1]]++;
                    }
                    else
                    {
                        dict.Add(input[1], 1);
                    }
                }

                Dictionary<string, int>.ValueCollection vc = dict.Values;

                int total = 1;

                foreach(int x in vc)
                {
                    total *= (x +1);
                }

                Console.WriteLine(total - 1);
            }
        }
    }
}


