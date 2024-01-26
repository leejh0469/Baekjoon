internal class Program
{
    static void Main(string[] args)
    {
        int day = int.Parse(Console.ReadLine());
        int aPage = int.Parse(Console.ReadLine());
        int bPage = int.Parse(Console.ReadLine());
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int c = (aPage % a) == 0 ? aPage / a : aPage / a + 1;
        int d = (bPage % b) == 0 ? bPage / b : bPage / b + 1;

        c = c > d ? c : d;

        Console.WriteLine(day - c);
    }
}