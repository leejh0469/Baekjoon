internal class Program
{
    static void Main(string[] args)
    {
        int x = 3000;

        for (int i = 0; i < 3;  i++)
        {
            int a = int.Parse(Console.ReadLine());
            if (x > a)
                x = a;
        }

        int y = 3000;

        for(int i = 0;i < 2; i++)
        {
            int a = int.Parse(Console.ReadLine());
            if(y > a) y = a;
        }

        Console.WriteLine(x + y - 50);
    }
}