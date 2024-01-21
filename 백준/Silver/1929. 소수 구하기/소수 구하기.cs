using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] deci = new int[input[1] + 1];

        List<int> list = new List<int>();
        for(int i = 2; i <= input[1]; i++)
        {
            if (deci[i] == 0)
            {
                list.Add(i);
                for(int j = 1; ; j++)
                {
                    if (i * j > input[1])
                        break;
                    deci[i * j] = 1;
                }
            }
        }

        StringBuilder sb = new StringBuilder();

        foreach(int i in list)
        {
            if (i < input[0])
                continue;
            if (i > input[1])
                break;

            sb.AppendLine(i.ToString());
        }

        Console.WriteLine(sb.ToString());
    }
}