internal class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
    
    Array.Sort(input);
    
    for(int i = 0; i < 3; i++){
        Console.WriteLine(input[i]);
    }
    }
}