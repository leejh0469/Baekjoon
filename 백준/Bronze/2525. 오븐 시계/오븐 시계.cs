internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int now = 60 * input[0] + input[1];

        int time = int.Parse(Console.ReadLine());

        int after = now + time;
        if(after >= 24 * 60)
        {
            after -= 24 * 60;
        }

        Console.WriteLine(after / 60 + " " + after % 60);
    }
}