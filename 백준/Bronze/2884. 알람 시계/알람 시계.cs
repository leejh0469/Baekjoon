internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int now = 60 * input[0] + input[1];
        int minus = 45;
        if(now < minus){
            minus -= now;
            now = 24*60;
        }
        
        now -= minus;

        Console.WriteLine(now / 60 + " " + now % 60);
    }
}