internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++) {
            int x = int.Parse(Console.ReadLine());
            if(x == 0)
            {
                int result;
                stack.TryPop(out result);
            }
            else
            {
                stack.Push(x);
            }
        }
        int sum = 0;
        foreach (int x in stack)
        {
            sum += x;
        }
        Console.WriteLine(sum);
    }
}